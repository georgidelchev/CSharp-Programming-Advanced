using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> carsList = new List<Car>();
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
        }

        public int Count
        {
            get => carsList.Count;
        }

        public string AddCar(Car car)
        {
            if (this.carsList.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (carsList.Count >= capacity)
            {
                return "Parking is full!";
            }

            carsList.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.carsList.All(x => x.RegistrationNumber != registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.carsList = this.carsList
                .Where(x => x.RegistrationNumber != registrationNumber)
                .ToList();

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car getCar = this.carsList
                .FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            return getCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                Car getCar = this.carsList
                    .FirstOrDefault(x => x.RegistrationNumber == item);

                if (getCar != null)
                {
                    this.carsList.Remove(getCar);
                }
            }
        }
    }
}
