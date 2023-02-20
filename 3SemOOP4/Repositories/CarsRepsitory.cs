using _3.Sem_OOP_1;

namespace _3SemOOP4.Repositories
{
    public class CarsRepsitory
    {
        private int _nextId;
        private List<Car>? _cars;

        public CarsRepsitory()
        {
            _nextId= 0;
            _cars = new List<Car>
            {
                new Car() {Id = _nextId++, Model = "BMW - 3 Series", LicensePlate = "AA17364", Price = 500000},
                new Car() {Id = _nextId++, Model = "BMW - 1 Series", LicensePlate = "BA34547", Price = 350000},
                new Car() {Id = _nextId++, Model = "BMW - X5", LicensePlate = "JD83485", Price = 450000},
                new Car() {Id = _nextId++, Model = "BMW - X3 Series", LicensePlate = "KG75646", Price = 400000}
            };
        }

        public List<Car>? GetAll() 
        { 
            return new List<Car>(_cars!);
        }

        public Car? GetById(int id)
        {
            Car? car = _cars!.Find(car => car.Id == id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars!.Add(newCar);
            return newCar;
        }

        public Car? Delete(int id) 
        { 
            Car? car = GetById(id);
            if (car != null)
            {
                _cars!.Remove(car);
                return car;
            }
            return null;
        }

        public Car? Update(int id, Car updatedCar)
        {
            updatedCar.Validate();
            Car? car = GetById(id);
            if(car != null) 
            { 
                car.Model = updatedCar.Model;
                car.LicensePlate = updatedCar.LicensePlate;
                car.Price = updatedCar.Price;
                return car;
            }
            return null;
        }
    }
}
