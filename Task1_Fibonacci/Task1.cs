using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Fibonacci
{
    /// <summary>
    /// static class that contains a method for the representation a Fibonacci sequence
    /// </summary>
    public static class Task1
    {
        /// <summary>
        /// represents a Fibonacci sequence
        /// </summary>
        /// <param name="n">indicates how much elements of sequence needs</param>
        /// <returns>N elements of the Fibonacci</returns>
        public static IEnumerable<int> Fibonacci(int n)
        {
            if (n < 0) throw new ArgumentException(nameof(n));
            int item1 = 1;
            int item2 = 1;
            if (n == 1) yield return item1;
            else if (n == 2)
            {
                yield return item2;
                yield return item1;
            }
            else
            {
                yield return item1;
                for (int i = 2; i <= n; i++)
                {
                    int buff = item2;
                    item2 += item1;
                    item1 = buff;
                    yield return item1;
                }
            }
        }
    }
}
