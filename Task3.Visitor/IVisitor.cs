using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Visitor
{
    public interface IVisitor
    {
        void Visit(Circle c);
        void Visit(Rectangle r);
        void Visit(Square s);
        void Visit(Triangle t);
    }
}
