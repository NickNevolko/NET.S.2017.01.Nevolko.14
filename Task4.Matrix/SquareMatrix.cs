using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    /// <summary>
    /// represents square matrix
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// array
        /// </summary>
        private T[,] arr;

        #region ctors


        /// <summary>
        /// ctor
        /// </summary>
        public SquareMatrix()
        {
            Size = 1;
            arr = new T[Size,Size];
        }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="size"></param>
        public SquareMatrix(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            arr = new T[size, size];
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="arr"></param>
        public SquareMatrix(T[,] arr)
        {
            if (ReferenceEquals(arr,null))
                throw new ArgumentNullException(nameof(arr));
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new ArgumentException("The length of the columns and rows must be equal");

            Size = arr.GetLength(0);
            this.arr = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this.arr[i, j] = arr[i, j];
        }

        /// <summary>
        /// implentation of inumerable t
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i <= Size-1; i++)
                for (int j = 0; j <= Size-1; j++)
                    yield return arr[i,j];
        }
        #endregion

        protected override T GetValue(int i, int j)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));

            return arr[i, j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            arr[i, j] = value;
        }
    }

}