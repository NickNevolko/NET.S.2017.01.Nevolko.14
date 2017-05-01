using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public interface IVisitor<T>
    {
        SquareMatrix<T> Visit(SquareMatrix<T> matrix);
        SquareMatrix<T> Visit(SymmetricMatrix<T> matrix);
        SquareMatrix<T> Visit(DiagonalMatrix<T> matrix);
    }
}
