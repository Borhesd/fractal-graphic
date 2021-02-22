using System;
using System.Collections.Generic;
using System.Text;

namespace SierpinskiFractal.Classes
{
    public class Point
    {
        public float X { get; set; }

        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point(Structures.Point point)
        {
            X = point.x;
            Y = point.y;
        }
    }
}
