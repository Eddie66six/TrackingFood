using System;

namespace TrackingFood.Core.Domain.Helpers
{
    public class Util
    {
        public double CalculateDistence(double defaultLatitude, double defaultLongitude,double latitude, double longitude)
        {
            const double r = 6371.0; // R is earth radius.
            var dLat = _toRadian(latitude - defaultLatitude);
            var dLon = _toRadian(longitude - defaultLongitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(_toRadian(defaultLatitude)) * Math.Cos(_toRadian(latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = r * c;

            return d;
        }

        private double _toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}