using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public class Area : IVisitor
    {
        public double AreaOfShape { get; set; }

        public void Visit(Square s)
        {
            AreaOfShape = s.Side * s.Side;
        }

        public void Visit(Triangle t)
        {
            double p = (t.A + t.B + t.C) / 2;
            AreaOfShape = Math.Sqrt(p * (p-t.A) * (p - t.B) * (p - t.C));
        }

        public void Visit(Rectangle r)
        {
            AreaOfShape = r.Height * r.Width;
        }

        public void Visit(Circle c)
        {
            AreaOfShape = Math.PI * Math.Pow(c.Radius, 2);
        }
    }
}
