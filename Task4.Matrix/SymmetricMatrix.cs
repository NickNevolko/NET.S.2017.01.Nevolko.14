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
    public class SymmetricMatrix<T> : Matrix<T>
    {
        T[][] arr;
        #region ctors
        /// <summary>
        /// ctor for empty matrix
        /// </summary>
        /// <param name="size"></param>
        public SymmetricMatrix(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            arr = new T[size][];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = new T[i + 1];
                for (int j = 0; j < i + 1; j++)
                    arr[i][j] = default(T);
            }
        }

        /// <summary>
        /// ctor 
        /// </summary>
        /// <param name="arr">array of T</param>
        public SymmetricMatrix(T[,] array)
        {
            if (ReferenceEquals(arr, null))
                throw new ArgumentNullException(nameof(arr));
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new ArgumentException("The length of the columns and rows must be equal");

            Size = array.GetLength(0);
            this.arr = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                this.arr[i] = new T[i + 1];
                for (int j = 0; j < i + 1; j++)
                    this.arr[i][j] = array[i, j];
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return this[i, j];
        }
        #endregion


        protected override T GetValue(int i, int j)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));

            return this.arr[i] [j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            this.arr[i][j] = value;
            this.arr[j][i] = value;
        }
    }
}
