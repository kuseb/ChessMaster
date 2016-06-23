using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using ObjLoader.Loader.Loaders;
using System.IO;

namespace Client
{
    public class ColoredCube : Volume
    {
        public Vector3 Center;
        public float SideLength, SideHeight, SideWidth;
       
        public LoadResult LoadModel()
        {
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream("chessboard.obj",FileMode.Open);
            var result = objLoader.Load(fileStream);

            return result;
        }
        public ColoredCube(float sideLength, float sideHeight, float sideWidth)//dlugosc, wysokosc i szerokosc
        {
            SideLength = sideLength;
            SideHeight = sideLength;
            SideWidth = sideWidth/5;

            //LoadResult result= LoadModel();

            //Center = new Vector3(0, 0, 0);

            //Vertices = new Vector3[result.Vertices.Count];
            //int i = 0;
            //foreach (var v in result.Vertices)
            //{
            //    Vertices[i] = new Vector3(v.X, v.Y, v.Z);
            //    i++;
            //}

            //Normals = new Vector3[result.Normals.Count];
            //i = 0;
            //foreach(var n in result.Normals)
            //{
            //    Normals[i] = new Vector3(n.X, n.Y, n.Z);
            //    i++;
            //}

            //Colors = new Vector4[result.Vertices.Count];
            //i = 0;
            //for(i=0;i<result.Vertices.Count;i++)
            //    Colors[i]= new Vector4(0.2f, 0.2f, 0.2f, 1.0f);



            Vertices = new Vector3[]
            {
                    //front
                    new Vector3(-SideLength, SideHeight, SideWidth),
                    new Vector3(-SideLength, -SideHeight, SideWidth),
                    new Vector3(SideLength, -SideHeight, SideWidth),
                    new Vector3(SideLength, SideHeight, SideWidth),
                    //back
                    new Vector3(-SideLength, SideHeight, -SideWidth),
                    new Vector3(-SideLength, -SideHeight, -SideWidth),
                    new Vector3(SideLength, -SideHeight, -SideWidth),
                    new Vector3(SideLength, SideHeight, -SideWidth),
                    //bottom
                    new Vector3(-SideLength, -SideHeight, -SideWidth),
                    new Vector3(-SideLength, -SideHeight, SideWidth),
                    new Vector3(SideLength, -SideHeight, SideWidth),
                    new Vector3(SideLength, -SideHeight, -SideWidth),
                    //top
                    new Vector3(-SideLength, SideHeight, -SideWidth),
                    new Vector3(-SideLength, SideHeight, SideWidth),
                    new Vector3(SideLength, SideHeight, SideWidth),
                    new Vector3(SideLength, SideHeight, -SideWidth),
                    //left
                    new Vector3(-SideLength, SideHeight, SideWidth),
                    new Vector3(-SideLength, -SideHeight, SideWidth),
                    new Vector3(-SideLength, -SideHeight, -SideWidth),
                    new Vector3(-SideLength, SideHeight, -SideWidth),
                    //right
                    new Vector3(SideLength, SideHeight, SideWidth),
                    new Vector3(SideLength, -SideHeight, SideWidth),
                    new Vector3(SideLength, -SideHeight, -SideWidth),
                    new Vector3(SideLength, SideHeight, -SideWidth)
            };

            Normals = new Vector3[]
            {
                    new Vector3(0f, 0f, 1f),
                    new Vector3(0f, 0f, 1f),
                    new Vector3(0f, 0f, 1f),
                    new Vector3(0f, 0f, 1f),

                    new Vector3(0f, 0f, -1f),
                    new Vector3(0f, 0f, -1f),
                    new Vector3(0f, 0f, -1f),
                    new Vector3(0f, 0f, -1f),

                    new Vector3(0f, -1f, 0f),
                    new Vector3(0f, -1f, 0f),
                    new Vector3(0f, -1f, 0f),
                    new Vector3(0f, -1f, 0f),

                    new Vector3(0f, 1f, 0f),
                    new Vector3(0f, 1f, 0f),
                    new Vector3(0f, 1f, 0f),
                    new Vector3(0f, 1f, 0f),

                    new Vector3(-1f, 0f, 0f),
                    new Vector3(-1f, 0f, 0f),
                    new Vector3(-1f, 0f, 0f),
                    new Vector3(-1f, 0f, 0f),

                    new Vector3(1f, 0f, 0f),
                    new Vector3(1f, 0f, 0f),
                    new Vector3(1f, 0f, 0f),
                    new Vector3(1f, 0f, 0f)
            };

            Colors = new Vector4[Vertices.Length];
            for (int i = 0; i < Colors.Length; i++)
                Colors[i] = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);

            Indices = new int[]
            {
                    //front
                    0, 1, 2, 0, 2, 3,
                    //back
                    4, 5, 6, 4, 6, 7,
                    //bottom
                    8, 9, 10, 8, 10, 11,
                    //////top
                    12, 13, 14, 12, 14, 15,
                    //////left
                    16, 17, 18, 16, 18, 19,
                    //////right
                    20, 21, 22, 20, 22, 23
            };
        }
    }
}
