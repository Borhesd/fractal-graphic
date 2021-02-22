using System;
using System.Collections.Generic;
using System.Text;

namespace SierpinskiFractal.Structures
{
    public struct Point
    {
        public float x;
        public float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Classes.Point point)
        {
            x = point.X;
            y = point.Y;
        }

        public static Point operator+(Point left, Point right)
        {
            return new Point(x:left.x + right.x,y:left.y + right.y);
        }

        public static Point operator -(Point left, Point right)
        {
            return new Point(x: left.x - right.x, y: left.y - right.y);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.x == right.x && left.y == right.y;
        }
        public static bool operator !=(Point left, Point right)
        {
            return left.x != right.x || left.y != right.y;
        }
        public override string ToString()
        {
            return $"{x},{y}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
