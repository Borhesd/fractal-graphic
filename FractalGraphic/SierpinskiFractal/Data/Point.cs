namespace SierpinskiFractal.Data
{
    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator+(Point left, Point right)
        {
            return new Point(x:left.X + right.X,y:left.Y + right.Y);
        }

        public static Point operator -(Point left, Point right)
        {
            return new Point(x: left.X - right.X, y: left.Y - right.Y);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.X == right.X && left.Y == right.Y;
        }
        public static bool operator !=(Point left, Point right)
        {
            return left.X != right.X || left.Y != right.Y;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
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
