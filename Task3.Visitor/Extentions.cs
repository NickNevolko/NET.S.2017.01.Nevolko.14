using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
   
    public static class Extentions
    {
      
        public static double GetArea(this Shape sh)
        {
            if (ReferenceEquals(sh, null)) throw new ArgumentNullException(nameof(sh));

            var visitor = new Area();
            sh.Accept(visitor);
            return visitor.AreaOfShape;
        }

        public static double GetPerimeter(this Shape sh)
        {
            if (ReferenceEquals(sh, null)) throw new ArgumentNullException(nameof(sh));

            var visitor = new Perimeter();
            sh.Accept(visitor);
            return visitor.PerimeterOfShape;
        }
    }
}
