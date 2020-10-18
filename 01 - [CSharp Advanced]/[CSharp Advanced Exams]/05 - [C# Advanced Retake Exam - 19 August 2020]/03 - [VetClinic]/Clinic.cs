using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> petsList;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.petsList = new List<Pet>();
        }

        public int Count
        {
            get => this.petsList.Count;
        }

        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.petsList.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.petsList.FirstOrDefault(x => x.Name == name);

            if (pet != null)
            {
                this.petsList.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.petsList.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.petsList.OrderByDescending(x => x.Age).FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var item in this.petsList)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
