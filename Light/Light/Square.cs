using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Light
{
    public class Square : IEnumerable
    {
        private int minX, maxX;
        private int minY, maxY;
        private Point[] array = new Point[4];

        public Square(Point p1, Point p2, Point p3, Point p4)
        {
            array[0] = p1;
            array[1] = p2;
            array[2] = p3;
            array[3] = p4;
        }

        public int MinX
        {
            get { return minX; }
        }
        public int MinY
        {
            get { return minY; }
        }
        public int MaxX
        {
            get { return maxX; }
        }
        public int MaxY
        {
            get { return maxY; }
        }

        public void MinMax()
        {
            minX = array[0].X;
            maxX = array[0].X;
            minY = array[0].Y;
            maxY = array[0].Y;
            for (int i = 0; i<array.Length; i++)
            {
                if (array[i].X < minX)
                {
                    minX = array[i].X;
                }
                if (array[i].X > maxX)
                {
                    maxX = array[i].X;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Y < minY)
                {
                    minY = array[i].Y;
                }
                if (array[i].Y > maxY)
                {
                    maxY = array[i].Y;
                }
            }

        }
        public Point this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }


        public IEnumerator GetEnumerator()
        {
            yield return array;
        }

    }
}
