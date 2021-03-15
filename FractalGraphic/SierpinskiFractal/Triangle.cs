using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SierpinskiFractal.Structures;

namespace SierpinskiFractal
{
    public class Triangle:ITriangle
    {
        public delegate void TriangleMessageHandler(string message);
        public delegate void TrianglePointsHandler(object point);

        public event TrianglePointsHandler CreatedPointsClass;
        public event TrianglePointsHandler CreatedPointsStruct;

        public event TriangleMessageHandler CreatedPoints;

        private List<Point> attractors = new List<Point>();
        private float figureSize = 0.165f;


        public Triangle(Classes.Size size)
        {
            attractors = GetAttractors(new Size(size));
        } 
        public Triangle(Size size)
        {
            attractors = GetAttractors(size);
        }

        public Triangle(float width, float height)
        {
            attractors = GetAttractors(new Size(width, height));
        }

        public Triangle() { }

        public void CreateAttractors(Classes.Size size)
        {
            attractors = GetAttractors(new Size(size));
        }

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
        private List<Point> GetAttractors(Size size)
        {
            //Расположение точки А исходя из заданного размера
            Point A = new Point(size.Width - (size.Width * figureSize),
                         size.Height - (size.Height * ((figureSize / 100f) * 6.06f)));

            //Расположение точки B исходя из заданного размера
            Point B = new Point(size.Width * figureSize,
                         size.Height - (size.Height * ((figureSize / 100f) * 6.06f)));
            
            //Расчет координаты X для точки C
            float xC = (float)((B.x - A.x) * Math.Cos(1.05f) - (B.y - A.y) * Math.Sin(1.05f) + A.x);
            //Расчет координаты Y для точки C
            float yC = (float)((B.x - A.x) * Math.Sin(1.05f) + (B.y - A.y) * Math.Cos(1.05f) + A.y);
            //Создание точки C
            Point C = new Point(xC, yC);
            
            return new List<Point> { A,B,C };
        }

        public List<Point> GetPointsStruct(int count)
        {
            List<Point> points = new List<Point>();
            PointGenerator pointGenerator = new PointGenerator(attractors);
            points.Add(pointGenerator.GetPoint(attractors[0], 0));
            for (int i = 1; i < count + 1; i++)
            {
                points.Add(pointGenerator.GetPoint(points[i-1], 0));
            }
            CreatedPointsStruct?.Invoke(points);
            CreatedPoints?.Invoke("Point(structures) created!");
            return points;
        }

        public List<Classes.Point> GetPointsClass(int count)
        {
            List<Classes.Point> points = new List<Classes.Point>();
            PointGenerator pointGenerator = new PointGenerator(attractors);
            points.Add(
                new Classes.Point(
                    pointGenerator.GetPoint(attractors[0], 0)));

            for (int i = 1; i < count + 1; i++)
            {
                points.Add(
                    new Classes.Point(
                        pointGenerator.GetPoint(
                                new Point(points[i - 1]), 0)));
            }
            CreatedPointsClass?.Invoke(points);
            CreatedPoints?.Invoke("Point(class) created!");
            return points;
        }

    }
}
