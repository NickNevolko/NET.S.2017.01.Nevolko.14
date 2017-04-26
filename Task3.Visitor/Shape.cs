using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public abstract class Shape
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit((dynamic)this);
        }
    }
}
