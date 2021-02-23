using System;
using System.Collections.Generic;
using SierpinskiFractal.Classes;
using SierpinskiFractal;

namespace HostAPI.Services
{
    public class TriangleFractalService: ITriangleFractalService
    {
        private Triangle triangle;

        public void CreateAttractors(float width, float height)
        {
            triangle = new Triangle(width, height);
        }
        public List<Point> CreateFractal(int pointCount)
        {
            return triangle?.GetPointsClass(pointCount);
        }
    }
}
