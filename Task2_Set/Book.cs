using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Set
{
    public class Book : IEquatable<Book>
    {
        int year;
        string author;
        int price;
        public Book(int year, int price, string  author)
        {
            this.year = year;
            this.author = author;
            this.price = price;
        }
        public bool Equals(Book other)
        {
            if (this.author == other.author &&
               this.price == other.price &&
               this.year == other.year)
                return true;
            else return false;

        }
    }
}
