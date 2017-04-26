using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public class Triangle : Shape
    {
        public double A { get; set; }
        public  double B { get; set; }
        public double C { get; set; }

        public Triangle(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
    }
}
