using System;
using System.Collections.Generic;
using SierpinskiFractal.Data;

namespace SierpinskiFractal
{
    public class Triangle:ITriangle
    {
        public delegate void TriangleMessageHandler(string message);
        public delegate void TrianglePointsHandler(object point);

        public event TrianglePointsHandler CreatedPointsStruct;

        public event TriangleMessageHandler CreatedPoints;

        private Point[] attractors;
        private float figureSize = 0.165f;

        public Triangle(Size size)
        {
            attractors = GetAttractors(size);
        }

        public Triangle(float width, float height)
        {
            attractors = GetAttractors(new Size(width, height));
        }

        public Triangle() { }

        public void CreateAttractors(Size size)
        {
            attractors = GetAttractors(size);
        }
       
        public void CreateAttractors(float width, float height)
        {
            attractors = GetAttractors(new Size(width,height));
        }
        /// <summary>
        /// Получение аттракторов в виде равнобедренного треугольника
        /// </summary>
        private Point[] GetAttractors(Size size)
        {
            //Расположение точки А исходя из заданного размера
            Point A = new Point(size.Width - (size.Width * figureSize),
                         size.Height - (size.Height * ((figureSize / 100f) * 6.06f)));

            //Расположение точки B исходя из заданного размера
            Point B = new Point(size.Width * figureSize,
                         size.Height - (size.Height * ((figureSize / 100f) * 6.06f)));
            
            //Расчет координаты X для точки C
            float xC = (float)((B.X - A.X) * Math.Cos(1.05f) - (B.Y - A.Y) * Math.Sin(1.05f) + A.X);
            //Расчет координаты Y для точки C
            float yC = (float)((B.X - A.X) * Math.Sin(1.05f) + (B.Y - A.Y) * Math.Cos(1.05f) + A.Y);
            //Создание точки C
            Point C = new Point(xC, yC);
            
            return new Point[] { A,B,C };
        }

        public Point[] GetPoints(int count)
        {
            List<Point> points = new List<Point>();
            PointGenerator pointGenerator = new PointGenerator(attractors);
            points.Add(pointGenerator.GetPoint(attractors[0], 0));
            for (int i = 1; i < count + 1; i++)
            {
                points.Add(pointGenerator.GetPoint(points[i-1], 0));
            }
            CreatedPointsStruct?.Invoke(points);
            CreatedPoints?.Invoke("Points created!");
            return points.ToArray();
        }

    }
}
