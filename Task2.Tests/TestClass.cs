using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Task2_Set;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Book_Test()
        {
            var set = new Set<Book>();
            var book = new Book(2017, 100, "author");
            set.Add(book);
            Assert.AreEqual(set.Contains(new Book(2017, 100, "author")), true);
            set.Remove(book);
            Assert.AreEqual(set.Contains(new Book(2017, 100, "author")), false);
        }

        [Test]
        public void Add_ArgumentNullException()
        {
            var set = new Set<string>();
            Assert.Throws<ArgumentNullException>(() => set.Add(null));
        }

        [Test]
        public void Add_Test()
        { 
            var set = new Set<string>(new[] { "lorem", "ipsum" });
            set.Add("dolor");
            Assert.AreEqual(set, new Set<string>(new[] { "lorem", "ipsum", "dolor" }));
        }

        [Test]
        public void Remove_Test()
        {
            var set = new Set<string>(new[] { "lorem", "ipsum", "dolor" });
            set.Remove("dolor");
            Assert.AreEqual(set, new Set<string>(new[] { "lorem", "ipsum" }));
            set[1] = "sit";
            Assert.AreEqual(set, new Set<string>(new[] { "lorem", "sit" }));
        }

        [Test]
        public void ExceptWith_Test()
        {
            var set = new Set<string>(new[] { "lorem", "ipsum", "dolor" });
            var set2 = new Set<string>(new[] { "sit", "amet", "dolor" });
            set.ExceptWith(set2);
            Assert.AreEqual(set, new[] { "lorem", "ipsum" });
        }

        [Test]
        public void Union_Test()
        {
            var set = new Set<string>(new[] { "lorem", "ipsum", "dolor" });
            var set2 = new Set<string>(new[] { "sit", "amet", "dolor" });
            set.UnionWith(set2);
            Assert.AreEqual(set, new[] { "lorem", "ipsum", "dolor", "sit", "amet"});
        }
    }
}
