using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(int r)
        {
            this.Radius = r;
        }
    }
}
