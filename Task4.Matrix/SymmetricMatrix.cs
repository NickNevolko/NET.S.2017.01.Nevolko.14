using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    /// <summary>
    /// /represents a symmetric square matrix
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// indexer
        /// </summary>
        /// <returns>value at i,j</returns>
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
                this.arr[i, j] = value;
                this.arr[j, i] = value;
                OnChange(this, new MatrixChangedEventArgs(i, j));
            }
        }

        #region ctors
        /// <summary>
        /// ctor for empty matrix
        /// </summary>
        /// <param name="size"></param>
        public SymmetricMatrix(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            arr = new T[size, size];
        }

        /// <summary>
        /// ctor 
        /// </summary>
        /// <param name="arr">array of T</param>
        public SymmetricMatrix(T[,] arr)
        {
            if (ReferenceEquals(arr, null))
                throw new ArgumentNullException(nameof(arr));
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new ArgumentException("The length of the columns and rows must be equal");

            Size = arr.GetLength(0);
            this.arr = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = arr[i, j];
        }
        #endregion
    }
}
