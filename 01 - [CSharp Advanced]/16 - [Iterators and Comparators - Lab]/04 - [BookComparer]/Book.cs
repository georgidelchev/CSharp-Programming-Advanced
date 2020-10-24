using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            var comparison = this.Year.CompareTo(other.Year);

            if (comparison == 0)
            {
                comparison = this.Title.CompareTo(other.Title);
            }

            return comparison;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
