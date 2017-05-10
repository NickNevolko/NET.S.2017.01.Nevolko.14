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
    public class DiagonalMatrix<T> : Matrix<T>
    {
        T[] arr;
        #region ctors
        public DiagonalMatrix(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            arr = new T[size];
        }

        public DiagonalMatrix(T[,] arr)
        {
            if (ReferenceEquals(arr, null))
                throw new ArgumentNullException(nameof(arr));
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new ArgumentException("The length of the columns and rows must be equal");

            Size = arr.GetLength(0);
            this.arr = new T[Size];

            for (int i = 0; i < Size; i++)
                    this.arr[i] = arr[i, i];
        }
        #endregion

        protected override T GetValue(int i, int j)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (i == j)
                return this.arr[i];
            else
                return default(T);
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i < 0 || i > Size)
                throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Size)
                throw new ArgumentOutOfRangeException(nameof(j));
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if (i == j)
                this.arr[i] = value;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var item in arr)
            {
                for (int i = 0; i < Size; i++)
                    for (int j = 0; j < Size; j++)
                        yield return this[i, j];
            }  
        }
    }
}
