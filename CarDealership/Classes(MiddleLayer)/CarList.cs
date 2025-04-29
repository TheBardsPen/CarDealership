using System.Collections.Generic;

namespace CarDealership
{
    public class CarList : List<Car>
    {
        // Overwriting the add method of List<T> to 
        // put new cars at the front of the list
        // to ease sorting for 'view all' method
        public new void Add(Car c)
        {
            base.Insert(0, c);
        }

        // Load method to grab from text file and fill in order
        public void Load()
        {
            List<Car> cars = CarsDB.LoadCars();
            foreach (Car c in cars)
                base.Add(c);
        }

        public void Save()
        {
            CarsDB.SaveCars(this);
        }
    }
}
