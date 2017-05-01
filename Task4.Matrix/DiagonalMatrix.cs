using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    /// <summary>
    /// represents a diagonal matrix
    /// </summary> <typeparam name="T">
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// indexer
        /// </summary>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Size)
                    throw new IndexOutOfRangeException(nameof(i));
                if (j < 0 || j > Size)
                    throw new IndexOutOfRangeException(nameof(j));
                return this.arr[i, j];
            }
            set
            {
                if (i < 0 || i > Size)
                    throw new IndexOutOfRangeException(nameof(i));
                if (j < 0 || j > Size)
                    throw new IndexOutOfRangeException(nameof(j));
                if (i != j)
                    throw new IndexOutOfRangeException(nameof(i));

                this.arr[i, j] = value;
                OnChange(this, new MatrixChangedEventArgs(i, j));
            }
        }

        #region ctors
        public DiagonalMatrix(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            arr = new T[size, size];
        }

        public DiagonalMatrix(T[,] arr)
        {
            if (ReferenceEquals(arr, null))
                throw new ArgumentNullException(nameof(arr));
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new ArgumentException("The length of the columns and rows must be equal");

            Size = arr.GetLength(0);
            this.arr = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                    this.arr[i, i] = arr[i, i];
        }
        #endregion
    }
}
