using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Client
{
    public abstract class Volume
    {
        protected Vector3[] Vertices;
        protected Vector3[] Normals;
        protected Vector4[] Colors;
        protected int[] Indices;

        protected Vector3 Translation;
        protected Vector3 Rotation; // in radians (.x - rotation around X axis etc.)
        protected Matrix4 RotationMatrix = Matrix4.Identity;
        protected Vector3 Scale = Vector3.One;

        protected Matrix4 ModelViewMatrix; // macierz transformacji obiektu we wspolrzednych lokalnych
        protected Matrix4 ModelViewProjectionMatrix; // macierz przeksztalcenia obiektu ze wspolrzednych lokalnych do wspolrzednych widzianych z kamery i rzutowanie na ekran

        //material properties
        protected Vector3 SpecularColor = new Vector3(1f, 1f, 1f);
        protected float SpecularExponent = 16f;

        protected List<Volume> Children = new List<Volume>();

        public void UpdateForDrawing(Camera activeCamera, Matrix4 projectionMatrix)
        {
            ModelViewMatrix = Matrix4.CreateScale(Scale)*RotationMatrix*
                              Matrix4.CreateTranslation(Translation);

            ModelViewProjectionMatrix = ModelViewMatrix*activeCamera.GetViewMatrix()*projectionMatrix;

            //optional updates of vertices, colors etc?
        }

        protected void CalculateNormals(Vector3[] verts, int[] indices)
        {
            Normals = new Vector3[verts.Length];
            int j = 0;
            Dictionary<int, Tuple<int, Vector3>> normals = new Dictionary<int, Tuple<int, Vector3>>();
            for (int i = 0; i < indices.Length; i++)
            {
                if (i != 0 && i % 3 == 0)
                    j+=3;
                Vector3 vec1 = new Vector3(verts[indices[j + 1]] - verts[indices[j + 2]]);
                Vector3 vec2 = new Vector3(verts[indices[j + 1]] - verts[indices[j]]);
                Vector3 averageNormal = Vector3.Cross(vec1, vec2);
                if (!normals.ContainsKey(indices[i]))
                    normals.Add(indices[i], new Tuple<int, Vector3>(1, averageNormal));
                else
                {
                    Tuple<int, Vector3> old = normals[indices[i]];
                    normals[indices[i]] = new Tuple<int, Vector3>(old.Item1 + 1, old.Item2 + averageNormal);
                }
            }
            for (int i = 0; i < normals.Count; i++)
            {
                Tuple<int, Vector3> norm = normals[i];
                Normals[i] = norm.Item2 / norm.Item1;
                Normals[i].Normalize();
            }
        }

        public void Translate(float x, float y, float z)
        {
            Translation += new Vector3(x, y, z);

            foreach(Volume v in Children)
                v.Translate(x, y, z);
        }

        public void Rotate(float x, float y, float z, Vector3 pivotPoint)//w radianach obrot wokol osi x, y i z
        {
            float mod = (float) (2f*Math.PI);
            Rotation += new Vector3(x, y, z);
            Rotation = new Vector3(Rotation.X % mod, Rotation.Y % mod, Rotation.Z % mod);

            //do poprzedniej rotacji dodaje aktualna
            RotationMatrix = RotationMatrix*Matrix4.CreateTranslation(-pivotPoint) * Matrix4.CreateRotationX(x)
            *Matrix4.CreateRotationY(y)*Matrix4.CreateRotationZ(z)*Matrix4.CreateTranslation(pivotPoint);

            foreach(Volume v in Children)
                v.Rotate(x, y, z, (pivotPoint + Translation - v.Translation));
        }

        public void AddChild(Volume v)
        {
            Children.Add(v);
        }

        public void RemoveChild(Volume v)
        {
            Children.Remove(v);
        }

        public Vector3 GetTranslation(){return Translation;}
        public Matrix4 GetRotationMatrix(){return RotationMatrix;}
        public Vector3 GetRotation(){return Rotation;}

        public Matrix4 GetModelView(){return ModelViewMatrix;}
        public Matrix4 CalculateModelView()
        {
            ModelViewMatrix = Matrix4.CreateScale(Scale) * RotationMatrix *
                Matrix4.CreateTranslation(Translation);
            return ModelViewMatrix;
        }
        public Matrix4 GetModelViewProjection(){return ModelViewProjectionMatrix;}

        public Vector3[] GetVertices(){return Vertices;}

        public Vector3[] GetNormals(){return Normals;}

        public Vector4[] GetColors(){return Colors;}

        public int[] GetIndices(){return Indices;}

        public Vector3 GetSpecularColor() { return SpecularColor; }

        public float GetSpecularExponent() { return SpecularExponent; }
    }
}
