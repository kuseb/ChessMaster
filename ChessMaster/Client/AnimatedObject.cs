using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Client
{
    public abstract class AnimatedObject
    {
        public abstract void DoAnimation(float deltaTime);
    }

    public class Chess : AnimatedObject
    {
        private ColoredCube chessBottom;
      

        private List<Volume> _path = new List<Volume>();
        private float timePassed = 0;

        private bool _machineMoving;
        private float _angleDiffOnXZ, _angleDiffOnXZProgress;
        private float _angleDiffOnYZ, _angleDiffOnYZProgress;
        private Vector3 _mainHorizontalArmTranslation, _mainHorizontalArmTranslationProgress;
        private float _pyramidExtendableArmTranslation, _pyramidExtendableArmTranslationProgress;

        private float _extendableArmInitialY;
        private float _rotatableArmPivotPointYOffset;

        public Chess()
        {
            chessBottom = new ColoredCube(400f, 100f, 200f);
            chessBottom.Translate(200f, -300f, 0f);
            GlRenderer.VolumesToDraw.Add(chessBottom);

            //ColoredCube dot = new ColoredCube(2, 2, 2);
            //dot.Translate(80, 110f, 0);
            //GlRenderer.VolumesToDraw.Add(dot);
            //ColoredCube dot2 = new ColoredCube(2, 2, 2);
            //dot2.Translate(80, 50f, 60);
            //GlRenderer.VolumesToDraw.Add(dot2);
            //ColoredCube dot3 = new ColoredCube(2, 2, 2);
            //dot3.Translate(80f, 50f + 40f, 44.7777f);
            //GlRenderer.VolumesToDraw.Add(dot3);
            //AddNewPath(new List<Volume>() { dot, dot2, dot3});

           
        }

        public override void DoAnimation(float deltaTime)
        {
            
            
        }
    }
}
