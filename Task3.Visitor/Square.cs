using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public class Square : Shape
    {
        public int Side { get; set; }

        public Square(int side)
        {
           this.Side = side;
        }
    }
}
