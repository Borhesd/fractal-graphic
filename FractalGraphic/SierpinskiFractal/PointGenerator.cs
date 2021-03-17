using System;
using System.Threading;
using System.Collections.Generic;
using SierpinskiFractal.Data;

namespace SierpinskiFractal
{
    class PointGenerator
    {
        public Point[] Attractors { get; set; }

        public PointGenerator(Point[] attractors)
        {
            Attractors = attractors;
        }

        public Point GetPoint(Point oldPoint, int coefficient)
        {
            Random random = RandomProvider.GetThreadRandom();
            Point attractor = Attractors[random.Next(0, Attractors.Length)];

            return new Point((oldPoint.X + (attractor.X * (1 + coefficient))) / (2 + coefficient),
                (oldPoint.Y + (attractor.Y * (1 + coefficient))) / (2 + coefficient));
        }

        public Point GetPoint(Point oldPoint, int coefficient, ref int selectAttractor)
        {
            Random random = RandomProvider.GetThreadRandom();
            selectAttractor = random.Next(0, Attractors.Length);
            Point attractor = Attractors[selectAttractor];

            return new Point((oldPoint.X + (attractor.X * (1 + coefficient))) / (2 + coefficient),
                (oldPoint.Y + (attractor.Y * (1 + coefficient))) / (2 + coefficient));
        }

    }

    public static class RandomProvider
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }
    }
}
