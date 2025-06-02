using System;
using System.Collections.Generic;
using CarDealership.Interfaces;

namespace CarDealership
{
    public class CarList<T> : List<T> where T : ICar
    {

        List<T> cars;

        public new int Count => cars.Count;

        public CarList()
        {
            cars = new List<T>(); 
        }

        // Overwriting the add method of List<T> to 
        // put new cars at the front of the list
        // to ease sorting for 'view all' method
        public new void Add(T car)
        {
            cars.Insert(0, car); // Changed
        }

        public List<T> ToList()
        {
            return new List<T>(cars);
        }

        public new void Remove(T car)
        {
            cars.Remove(car);
        }
        public new void RemoveAt(int index)
        {
            cars.RemoveAt(index);
        }

        public new IEnumerator<T> GetEnumerator()
        {
            foreach (T car in cars)
            {
                yield return car;
            }
        }

        public new T this[int i]
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
