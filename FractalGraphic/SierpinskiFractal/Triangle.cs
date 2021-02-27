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

        //ПЕРЕДЕЛАЙ НАХУЙ
        private List<Point> GetAttractors(Size size)
        {
            List<Point> _attractors = new List<Point>()
                    {
                        new Point(size.Width - (size.Width*figureSize),
                         size.Height - (size.Height*((figureSize/100f) * 6.06f))),

                        new Point(size.Width*figureSize,//0.165f
                         size.Height - (size.Height*((figureSize/100f) * 6.06f)))
                    };

            _attractors.Add(new Point(
                   (float)((_attractors[1].x - _attractors[0].x) * Math.Cos(1.05f) -
                   (_attractors[1].y - _attractors[0].y) * Math.Sin(1.05f) + _attractors[0].x),
                   (float)((_attractors[1].x - _attractors[0].x) * Math.Sin(1.05f) +
                   (_attractors[1].y - _attractors[0].y) * Math.Cos(1.05f) + _attractors[0].y)
                   ));

            return _attractors;
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
