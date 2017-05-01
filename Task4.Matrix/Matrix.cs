using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Matrix
{
    /// <summary>
    /// abstract entity of the matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        /// <summary>
        /// size
        /// </summary>
        public int Size { get; protected set; }
        public event EventHandler<MatrixChangedEventArgs> Change = delegate { };

        public abstract T this[int i, int j] { get; set; }

        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit((dynamic)this);
        }

        protected virtual void OnChange(object sender, MatrixChangedEventArgs e)
        {
            Change(sender, e);
        }

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MatrixChangedEventArgs : EventArgs
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public MatrixChangedEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
