using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public static class MatrixExtension
    {
        public static Matrix<T> Add<T>(this Matrix<T> matrix, Matrix<T> other, IAdder<T> adder)
        {
            var visitor = new MatrixAdder<T>(other, adder);
            matrix.Accept(visitor);
            return visitor.Result;
        }
    }
}
