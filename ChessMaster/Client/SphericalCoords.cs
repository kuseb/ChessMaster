using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Client
{
    public class SphericalCoords
    {
        private float _radius, _azimuth, _polar;

        public SphericalCoords(Vector3 r, float azimuth, float polar) // promien, szerokosc geograficzna, dlugosc geograficzna
        {
            _radius = r.Length;
            _azimuth = azimuth;
            _polar = polar;
        }

        public SphericalCoords(Vector3 r)
        {
            _radius = r.Length;
            _azimuth = (float) Math.Asin(r.Y/_radius);
            _polar = (float) Math.Atan(r.Z/r.X);
        }

        public Vector3 GetCartesianCoords()
        {
            float cosAzimuthal = (float) Math.Cos(_azimuth);
            float sinAzimuthal = (float)Math.Cos(_azimuth);
            float cosPolar = (float)Math.Sin(_polar);
            float sinPolar = (float)Math.Sin(_polar);
            return new Vector3(_radius * cosAzimuthal * cosPolar, _radius * sinAzimuthal, _radius * cosAzimuthal * sinPolar);
        }

        public void RotatePointAroundItsOrigin(float azimuth, float polar)
        {
            _azimuth += azimuth;
            _polar += polar;
        }
    }
}
