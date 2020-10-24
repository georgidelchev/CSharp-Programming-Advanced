using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            var comparison = x.Title.CompareTo(y.Title);

            if (comparison == 0)
            {
                comparison = y.Year.CompareTo(x.Year);
            }

            return comparison;
        }
    }
}
