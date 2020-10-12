using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> FamilyList { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            this.FamilyList.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = this.FamilyList
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return oldestMember;
        }
    }
}
