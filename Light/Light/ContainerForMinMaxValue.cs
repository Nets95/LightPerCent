using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Light
{
    class ContainerForMinMaxValue:IEnumerable
    {
        List<Point> container = new List<Point>();
        private int count;

        public int Count
        {
            get { return count; }
        }
        public void Add(Square sq)
        {
            container.Add(new Point(sq.MinX,sq.MinY));
            count++;
            container.Add(new Point(sq.MaxX, sq.MaxY));
            count++;
        }
        public Point this[int i]
        {
            get { return container[i];}
        }

        public IEnumerator GetEnumerator()
        {
            yield return container;
        }

    }
}
