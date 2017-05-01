using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Matrix;

namespace Task4.Tests
{
    [TestFixture]
    public class MatrixesTests
    {
        int[,] arr = {
            { 1, 2, 3, 4 },
            { 4, 2, 1, 3 },
            { 1, 3, 2, 4 },
            { 4, 3, 1, 2 }
        };

        [Test]
        public void SquareMatrix_Test()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(arr);
            SquareMatrix<int> s1 = new SquareMatrix<int>(arr);
            Matrix<int> result = s.Add(s1, new Addr());
            Matrix<int> expected = new SquareMatrix<int>(new int[,] {
                { 2, 4, 6, 8 },
                { 8, 4, 2, 6 },
                { 2, 6, 4, 8 },
                { 8, 6, 2, 4 }
            });
            Assert.AreEqual(result, expected);
        }

            [Test]
            public void DiagonalMatrix_Test()
            {
                DiagonalMatrix<int> s = new DiagonalMatrix<int>(arr);
                DiagonalMatrix<int> s1 = new DiagonalMatrix<int>(arr);
                Matrix<int> result = s.Add(s1, new Addr());
                Matrix<int> expected = new DiagonalMatrix<int>( new int[,] {
                { 2, 2, 2, 8 },
                { 4, 4, 1, 3 },
                { 2, 3, 4, 4 },
                { 8, 3, 1, 4 }
                });
                Assert.AreEqual(result, expected);
            }

            [Test]
            public void SymmetricMatrix_Test()
            {
            int[,] arr = {
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 1, 4, 1, 1 },
                    { 1, 1, 1, 1 }
                };
                SymmetricMatrix<int> s = new SymmetricMatrix<int>(arr);
                SymmetricMatrix<int> s1 = new SymmetricMatrix<int>(arr);
                Matrix<int> result = s.Add(s1, new Addr());
                Matrix<int> expected = new SymmetricMatrix<int>( new int[,] {
                    { 2, 2, 2, 2 },
                    { 2, 2, 8, 2 },
                    { 2, 8, 2, 2 },
                    { 2, 2, 2, 2 }
                });
                Assert.AreEqual(result, expected);
            }
        }

    class Addr : IAdder<int>
    {
        public int Add(int first, int second)
        {
            return first + second;
        }
    }
}
