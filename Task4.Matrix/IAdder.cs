using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public interface IAdder<T>
    {
        T Add(T item1, T item2);
    }
}
