using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Client
{
    class GlRenderer
    {
        private static readonly double MaxZDepth = 10000f;
        private static readonly double MaxZNear = 100f;

        private OpenTK.Matrix4 _projectionMatrix;

        private int _screenWidth, _screenHeight;

        public Stopwatch Timer;
        public long LastFrameTime;
        private const int GameFps = 60; // ilosc klatek na sekunde
        static readonly int AnimationTimeStep = 1000 / GameFps; //czas trwania pojedynczej klatki w ms
        public long Accumulator = 0; // metoda stalokrokowa

        public class Light
        {
            public Vector4 position; // zakladam ze point light maja 0 jako .w a directional 1
            public Vector3 intensities; //a.k.a. the chessColor of the light
            public float attenuation;
            public float ambientCoefficient;
            public float coneAngle;
            public Vector3 coneDirection;
        };
        public List<Light> activeLights = new List<Light>();

        private Dictionary<String, ShaderProgram> shaders = new Dictionary<string, ShaderProgram>();
        private ShaderProgram activeShader;
        public static List<Volume> VolumesToDraw = new List<Volume>();
        public static List<AnimatedObject> AnimatedObjects = new List<AnimatedObject>();
        public Camera ActiveCamera;

        public Chess MillingMachine;

        public GlRenderer()
        {
            Timer = new Stopwatch();
            Timer.Start();
            LastFrameTime = Timer.ElapsedMilliseconds;
        }

        public void InitializeGl(int viewportWidth, int viewportHeight)
        {
            _screenWidth = viewportWidth;
            _screenHeight = viewportHeight;

            CreateShaders();

            //_projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(1.3f, viewportWidth / (float)viewportHeight, 1.0f, (float)MaxZDepth);
            float far = (float)MaxZDepth;
            float near = (float) MaxZNear;
            float fov = (float)(90f / 180f * Math.PI);
            float e = (float)(1f / Math.Tan(fov / 2f));
            float a = (float)viewportHeight / (float)viewportWidth;

            _projectionMatrix = new Matrix4(
                e, 0, 0, 0,
                0, e / a, 0, 0,
                0, 0, -(far + near) / (far - near), -2f * far * near / (far - near),
                0, 0, -1, 0);
            _projectionMatrix.Transpose();
            ActiveCamera = new Camera(new Vector3(0f, 0f, -1000f), -Vector3.UnitZ, Vector3.UnitY);

            MillingMachine = new Chess();
            AnimatedObjects.Add(MillingMachine);

            Light pointLight = new Light()
            {
                position = new Vector4(2000, 2000, 0, 0), // w = 0 => point light
                intensities = new Vector3(0.9f, 0.8f, 0.8f),
                ambientCoefficient = 0.9f
            };
            activeLights.Add(pointLight);

            Light pointLight2 = new Light()
            {
                position = new Vector4(-2000, 2000, -2000, 0), // w = 0 => point light
                intensities = new Vector3(0.9f, 0.8f, 0.8f),
                ambientCoefficient = 0.1f
            };
            activeLights.Add(pointLight2);

            // inicjalizacja glebi i blendingu

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.DepthMask(true);
            GL.DepthRange(0.0d, MaxZDepth); // !!!!!!!!!!!!!!!!!! Uwaga na przeciazona wersje przyjmujaca 2 floaty a tutaj trzeba 2 double dac

            GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
        }

        private void CreateShaders()
        {
            shaders.Add("triangles", new ShaderProgram("shaders/triangles/vertexShader.glsl", "shaders/triangles/fragmentShader.glsl", true));

            activeShader = shaders["triangles"];
        }

        public void Render()
        {
            // Get the current time
            long now = Timer.ElapsedMilliseconds;
            long elapsed = now - LastFrameTime;
            Accumulator += elapsed;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            while (Accumulator - AnimationTimeStep > 0)
            {
                foreach (AnimatedObject ao in AnimatedObjects)
                    ao.DoAnimation(AnimationTimeStep);

                Accumulator -= AnimationTimeStep;
            }
            LastFrameTime = now;

            RenderTriangles();

            GL.Flush();
        }

        private void RenderTriangles()
        {
            GL.UseProgram(activeShader.ProgramID);

            int modelViewProjectionLoc = activeShader.GetUniform("u_MVPMatrix");
            int modelLoc = activeShader.GetUniform("u_model");
            int cameraViewLoc = activeShader.GetUniform("u_cameraView");
            int cameraPositionLoc = activeShader.GetUniform("u_cameraPosition");
            int materialSpecularLoc = activeShader.GetUniform("u_materialSpecular");
            int materialSpecExponentLoc = activeShader.GetUniform("u_materialSpecExponent");
            
            Matrix4 cameraView = ActiveCamera.GetViewMatrix();
            GL.UniformMatrix4(cameraViewLoc, false, ref cameraView);
            GL.Uniform3(cameraPositionLoc, ActiveCamera.GetPosition());

            activeShader.EnableVertexAttribArrays();

            foreach (Volume v in VolumesToDraw)
            {
                int indicesAmount = UpdateImageGeometry(v);

                var modelViewProjection = v.GetModelViewProjection();
                GL.UniformMatrix4(modelViewProjectionLoc, false, ref modelViewProjection);

                var modelView = v.GetModelView();
                GL.UniformMatrix4(modelLoc, false, ref modelView);

                GL.Uniform3(materialSpecularLoc, v.GetSpecularColor());

                GL.Uniform1(materialSpecExponentLoc, v.GetSpecularExponent());

                GL.Uniform1(activeShader.GetUniform("u_numLights"), activeLights.Count);
                for (int i = 0; i < activeLights.Count; i++)
                {
                    Light light = activeLights[i];
                    string name = "u_allLights[" + i + "].";
                    GL.Uniform4(GL.GetUniformLocation(activeShader.ProgramID, name + "position"), light.position);
                    GL.Uniform3(GL.GetUniformLocation(activeShader.ProgramID, name + "intensities"), light.intensities);
                    GL.Uniform1(GL.GetUniformLocation(activeShader.ProgramID, name + "attenuation"), light.attenuation);
                    GL.Uniform1(GL.GetUniformLocation(activeShader.ProgramID, name + "ambientCoefficient"), light.ambientCoefficient);
                    GL.Uniform1(GL.GetUniformLocation(activeShader.ProgramID, name + "coneAngle"), light.coneAngle);
                    GL.Uniform3(GL.GetUniformLocation(activeShader.ProgramID, name + "coneDirection"), light.coneDirection);
                }

                GL.DrawElements(PrimitiveType.Triangles, indicesAmount,
                DrawElementsType.UnsignedInt, IntPtr.Zero);
            }

            activeShader.DisableVertexAttribArrays();
        }

        public int UpdateImageGeometry(Volume volume)
        {
            volume.UpdateForDrawing(ActiveCamera, _projectionMatrix);

            Vector3[] verticesArrayObject = volume.GetVertices();
            Vector3[] normalsArrayObject = volume.GetNormals();
            Vector4[] colorsArrayObject = volume.GetColors();
            int[] indicesArrayObject = volume.GetIndices();

            GL.BindBuffer(BufferTarget.ArrayBuffer, activeShader.GetBuffer("i_position"));
            GL.BufferData<OpenTK.Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(verticesArrayObject.Length * OpenTK.Vector3.SizeInBytes),
                verticesArrayObject, BufferUsageHint.DynamicDraw);

            //najpierw trzeba GL.EnableVertexAttribArray(attrLoc) ale to jest uruchamiane tuz przed wywolaniem tej metody dla wszystkich atrybutow i disablowane po narysowaniu
            GL.VertexAttribPointer(activeShader.GetAttribute("i_position"), 3, VertexAttribPointerType.Float, false, OpenTK.Vector3.SizeInBytes, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ArrayBuffer, activeShader.GetBuffer("i_normal"));
            GL.BufferData<OpenTK.Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(normalsArrayObject.Length * OpenTK.Vector3.SizeInBytes),
                normalsArrayObject, BufferUsageHint.DynamicDraw);

            GL.VertexAttribPointer(activeShader.GetAttribute("i_normal"), 3, VertexAttribPointerType.Float, false, OpenTK.Vector3.SizeInBytes, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ArrayBuffer, activeShader.GetBuffer("i_color"));
            GL.BufferData<OpenTK.Vector4>(BufferTarget.ArrayBuffer,
                new IntPtr(colorsArrayObject.Length * OpenTK.Vector4.SizeInBytes),
                colorsArrayObject, BufferUsageHint.DynamicDraw);

            GL.VertexAttribPointer(activeShader.GetAttribute("i_color"), 4, VertexAttribPointerType.Float, false, OpenTK.Vector4.SizeInBytes, IntPtr.Zero);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, activeShader.GetBuffer("index"));
            GL.BufferData<int>(BufferTarget.ElementArrayBuffer,
                new IntPtr(indicesArrayObject.Length * sizeof(int)),
                indicesArrayObject, BufferUsageHint.StaticDraw);

            return indicesArrayObject.Length;
        }

    }
}
