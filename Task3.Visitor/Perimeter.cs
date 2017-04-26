using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public class Perimeter : IVisitor
    {
        public double PerimeterOfShape{get; set;}

        public void Visit(Square s)
        {
            PerimeterOfShape = s.Side * 4;
        }

        public void Visit(Triangle t)
        {
            PerimeterOfShape = t.A + t.B + t.C;
        }

        public void Visit(Rectangle r)
        {
            PerimeterOfShape = 2 * (r.Height + r.Width);
        }

        public void Visit(Circle c)
        {
           PerimeterOfShape = 2 * Math.PI * c.Radius;
        }
    }
}
