using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    public class MatrixAdder<T> : IVisitor<T>
    {
        private Matrix<T> Other;
        public Matrix<T> Result;
        private IAdder<T> Adder;

        public MatrixAdder(Matrix<T> Other, IAdder<T> adder)
        {
            this.Adder = adder;
            this.Other = Other;
        }

        public SquareMatrix<T> Visit(DiagonalMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.Size != Other.Size)
                throw new ArgumentException("Matrix sizes are not equal");

            Result = new SquareMatrix<T>(Other.Size);

            for (int i = 0; i < Other.Size; i++)
                for (int j = 0; j < Other.Size; j++)
                    Result[i, j] = Adder.Add(matrix[i, j], Other[i, j]);
            return (SquareMatrix<T>)Result;

        }

        public SquareMatrix<T> Visit(SymmetricMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.Size != Other.Size)
                throw new ArgumentException("Matrix sizes are not equal");

            Result = new SquareMatrix<T>(Other.Size);

            for (int i = 0; i < Other.Size; i++)
                for (int j = 0; j < Other.Size; j++)
                    Result[i, j] = Adder.Add(matrix[i, j], Other[i, j]);
            return (SquareMatrix<T>)Result;
        }

        public SquareMatrix<T> Visit(SquareMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.Size != Other.Size)
                throw new ArgumentException("Matrix sizes are not equal");

            Result = new SquareMatrix<T>(Other.Size);

            for (int i = 0; i <= Other.Size-1; i++)
                for (int j = 0; j <= Other.Size-1; j++)
                    Result[i, j] = Adder.Add(matrix[i,j], Other[i,j]);
            return (SquareMatrix<T>)Result;
        }
    }
}
