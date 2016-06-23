using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Client
{
    public class Camera
    {
        private Matrix4 _viewMatrix;//macierz przeksztalcenia wierzcholkow obiektow z ukl lokalnego na wierzcholki widziane przez kamere
        private bool _cameraChanged = true;

        private Vector3 _position;
        private Vector3 _cameraTarget;
        private Vector3 _upVector;

        private SphericalCoords _sphericalPos;

        public Camera(Vector3 pos, Vector3 target, Vector3 upVec)
        {
            _upVector = upVec;
            SetPosition(pos.X, pos.Y, pos.Z);
            SetTarget(target.X, target.Y, target.Z);

            _sphericalPos = new SphericalCoords(pos - target);
        }

        public Matrix4 GetViewMatrix()
        {
            if (_cameraChanged)
            {
                UpdateCamera();
                _cameraChanged = false;
            }
            return _viewMatrix;
        }

        public Vector3 GetPosition(){return _position;}

        private void UpdateCamera()
        {
            Vector3 zAxis = _position - _cameraTarget;
            zAxis.Normalize();
            Vector3 xAxis = Vector3.Cross(_upVector, zAxis);
            xAxis.Normalize();
            Vector3 yAxis = Vector3.Cross(zAxis, xAxis);
            yAxis.Normalize();

            _viewMatrix = new Matrix4(xAxis.X, yAxis.X, zAxis.X, _position.X,
                xAxis.Y, yAxis.Y, zAxis.Y, _position.Y,
                xAxis.Z, yAxis.Z, zAxis.Z, _position.Z,
                0f, 0f, 0f, 1f);
            _viewMatrix.Transpose();
            _viewMatrix.Invert();
        }

        public void SetTarget(float x, float y, float z)
        {
            _cameraChanged = true;
            _cameraTarget = new Vector3(x, y, z);
        }

        public void SetPosition(float x, float y, float z)
        {
            _cameraChanged = true;
            _position = new Vector3(x, y, z);
        }

        public void MoveCamera(float dx, float dy, float dz)
        {
            _cameraChanged = true;
            Vector3 translation = new Vector3(dx, dy, dz);
            _position += translation;
        }
        public void MoveCameraWithTarget(float dx, float dy, float dz)
        {
            _cameraChanged = true;
            Vector3 translation = new Vector3(dx, dy, dz);
            _position += translation;
            _cameraTarget += translation;
        }

        public void MoveCameraWithTargetInItsLocalAxes(float dx, float dy, float dz)
        {
            Vector3 zAxis = _position - _cameraTarget;
            zAxis.Normalize();
            Vector3 xAxis = Vector3.Cross(_upVector, zAxis);
            xAxis.Normalize();
            Vector3 yAxis = Vector3.Cross(zAxis, xAxis);
            yAxis.Normalize();

            Vector3 translation = dx*xAxis + dy*yAxis + dz*zAxis;
            MoveCameraWithTarget(translation.X, translation.Y, translation.Z);
        }

        public void MoveTarget(float dx, float dy, float dz)
        {
            _cameraChanged = true;
            _cameraTarget += new Vector3(dx, dy, dz);
        }

        public void RotateAroundTarget(float angleX, float angleY, float angleZ)
        {
            _cameraChanged = true;
            Vector3 zAxis = _position - _cameraTarget;
            zAxis.Normalize();
            Vector3 xAxis = Vector3.Cross(_upVector, zAxis);
            xAxis.Normalize();
            Vector3 yAxis = Vector3.Cross(zAxis, xAxis);
            yAxis.Normalize();

            //_sphericalPos = new SphericalCoords(_position);
            //_sphericalPos.RotatePointAroundItsOrigin(angleX, angleY);
            ////_position -= _cameraTarget;
            //_position = _sphericalPos.GetCartesianCoords();
            ////_position += _cameraTarget;
            Quaternion qx = new Quaternion((float)Math.Sin(angleX / 2f) * xAxis, (float)Math.Cos(angleX / 2f));
            Quaternion qy = new Quaternion((float)Math.Sin(angleY / 2f) * yAxis, (float)Math.Cos(angleY / 2f));
            Quaternion qz = new Quaternion((float)Math.Sin(angleZ / 2f) * zAxis, (float)Math.Cos(angleZ / 2f));
            Matrix4 rot = Matrix4.Invert(Matrix4.CreateFromQuaternion(qx * qy * qz));
            _position = Vector3.Transform(_position, rot);
            //Matrix4 rotation = RotateAroundAxis(xAxis, angleX) * RotateAroundAxis(yAxis, angleY) * RotateAroundAxis(zAxis, angleZ);
            //_position = Vector3.Transform(_position, rotation);
            //_position += _cameraTarget;
        }

        private Matrix4 RotateAroundAxis(Vector3 u, float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);
            Matrix4 rotation = new Matrix4(new Vector4(u.X * u.X + (1f - u.X * u.X) * c, u.X * u.Y * (1f - c) - u.Z * s, u.X * u.Z * (1f - c) + u.Y * s, 0f),
                new Vector4(u.X * u.Y * (1f - c) + u.Z * s, u.Y * u.Y + (1f - u.Y * u.Y) * c, u.Y * u.Z * (1f - c) - u.X * s, 0f),
                new Vector4(u.X * u.Z * (1f - c) - u.Y * s, u.Y * u.Z * (1f - c) + u.X * s, u.Z * u.Z + (1f - u.Z * u.Z) * c, 0f),
                new Vector4(0, 0, 0, 1f));
            return rotation;
        }

        public void Zoom(float z)
        {
            _cameraChanged = true;
            Vector3 zAxis = _position -_cameraTarget;
            zAxis.Normalize();
            zAxis *= z;
            MoveCamera(zAxis.X, zAxis.Y, zAxis.Z);
        }
    }
}
