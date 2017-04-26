using NUnit.Framework;
using System;
using Task3.Visitor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Visitor_Test()
        {
            var c = new Circle(3);
            var r = new Rectangle(2, 4);
            var s = new Square(4);
            var t = new Triangle(1, 2, 3);

            Assert.AreEqual(c.GetPerimeter(), Math.PI * c.Radius * 2);
            Assert.AreEqual(c.GetArea(), Math.PI * c.Radius * c.Radius);

            Assert.AreEqual(r.GetPerimeter(), 12);
            Assert.AreEqual(r.GetArea(), 8);

            Assert.AreEqual(s.GetPerimeter(), 16);
            Assert.AreEqual(s.GetArea(), 16);

            Assert.AreEqual(t.GetPerimeter(), 6);
        }
    }
}
