using System;

namespace NavigatorDemo.Common
{
    public static class NumericExtensions
    {
        public static double DegreeToRadian(this int angle)
        {
            return Math.PI * (0.0 + angle) / 180.0;
        }
    }
}
