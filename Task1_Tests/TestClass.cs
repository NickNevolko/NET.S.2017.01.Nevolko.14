using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Task1_Fibonacci.Task1;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Tests
{
    [TestFixture]
    public class TestClass
    {
        int[] arr1 = { 1, 1, 2, 3, 5 };
        int[] arr2 = { 1};
        int[] arr3 = { 1, 1};
        int[] arr4 = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144};
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(arr1, Fibonacci(5));
            Assert.AreEqual(arr2, Fibonacci(1));
            Assert.AreEqual(arr3, Fibonacci(2));
            Assert.AreEqual(arr4, Fibonacci(12));
        }
    }
}
