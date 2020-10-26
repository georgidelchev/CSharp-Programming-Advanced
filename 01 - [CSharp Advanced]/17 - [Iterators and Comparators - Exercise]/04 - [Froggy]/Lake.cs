using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int>elements)
        {
            this.stones = new List<int>(elements);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            int currentIndex = this.stones.Count-1;

            if (currentIndex % 2 == 0)
            {
                currentIndex--;
            }

            for (int i = currentIndex; i >= 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
