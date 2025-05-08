using System.Collections.Generic;
using CarDealership.Interfaces;

namespace CarDealership
{
    public class CarList //: List<Car>
    {

        List<ICar> cars;

        public CarList()
        {
            cars = new List<ICar>();
        }
        // Overwriting the add method of List<T> to 
        // put new cars at the front of the list
        // to ease sorting for 'view all' method
        public void Add(ICar car)
        {
            cars.Add(car); // Changed
        }

        // Load method to grab from text file and fill in order
        public void Load()
        {
            List<ICar> loadedCars = CarsDB.LoadCars();
            foreach (ICar c in loadedCars)
                cars.Add(c);
        }

        public void Save()
        {
            CarsDB.SaveCars(cars);
        }
    }
}
