using System;
using System.Collections.Generic;
using CarDealership.Interfaces;

namespace CarDealership
{
    public class CarList<T> where T : ICar
    {

        List<T> cars;

        public int Count => cars.Count;
        public int NextID = 0;

        public CarList()
        {
            cars = new List<T>(); 
        }

        // Overwriting the add method of List<T> to 
        // put new cars at the front of the list
        // to ease sorting for 'view all' method
        public void Add(T car)
        {
            cars.Insert(0, car); // Changed
        }

        public int GetNextID()
        {
            CarsDB<ICar>.NextID++;
            this.NextID = CarsDB<ICar>.NextID;

            return NextID;
        }

        public List<T> ToList()
        {
            return new List<T>(cars);
        }

        public void Remove(T car)
        {
            cars.Remove(car);
        }
        public void RemoveAt(int index)
        {
            cars.RemoveAt(index);
        }

        public void MarkSold(T car)
        {
            car.IsSold = true;
        }

        public void MarkUnsold(T car)
        {
            car.IsSold = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T car in cars)
            {
                yield return car;
            }
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= cars.Count)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }

                return cars[i];
            }
            set
            {
                cars[i] = value;
            }
        }

        // Load method to grab from text file and fill in order
        public void Load()
        {
            List<T> loadedCars = CarsDB<T>.LoadCars();
            foreach (T c in loadedCars)
                cars.Add(c);
        }

        public void Save()
        {
            CarsDB<T>.SaveCars(cars);
        }
    }
}
