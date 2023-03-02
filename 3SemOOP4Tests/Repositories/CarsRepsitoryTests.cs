using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3SemOOP4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.Sem_OOP_1;

namespace _3SemOOP4.Repositories.Tests
{
    [TestClass()]
    public class CarsRepsitoryTests
    {
        private CarsRepsitory? _repository;

        [TestInitialize()]
        public void Initialize()
        {
            _repository = new CarsRepsitory();
        }

        [TestMethod()]
        public void CarsRepsitoryTest()
        {

        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Car>? cars = _repository!.GetAll();
            Assert.IsNotNull(cars);
            Assert.IsInstanceOfType(cars, typeof(List<Car>));
            Assert.AreEqual(4, cars.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            int car_id = 1;
            Car? car = _repository!.GetById(car_id);
            Assert.IsNotNull(car);
            Assert.AreEqual(car_id, car.Id);
        }

        [TestMethod()]
        public void AddTest()
        {
            Car? car = _repository!.Add(new Car() { Model = "BMW - 5 Series", LicensePlate = "DF34523", Price = 560000});
            Car? newCar = _repository!.GetById(4);
            Assert.AreSame(car, newCar, "Are not the same");
            Assert.IsInstanceOfType(car, typeof(Car));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int car_id = 1;
            int repositoryCount = _repository!.GetAll()!.Count();

            Car? car = _repository!.Delete(car_id);
            Assert.AreNotEqual(repositoryCount, _repository!.GetAll()!.Count());

            Car? nullCar = _repository!.GetById(car_id);
            Assert.IsNull(nullCar);

            nullCar = _repository!.Delete(car_id);
            Assert.IsNull(nullCar);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            int car_id = 1;

            //Non changed car
            Car car = new Car
            {
                Id = _repository!.GetById(car_id)!.Id,
                Model = _repository!.GetById(car_id)!.Model,
                LicensePlate = _repository!.GetById(car_id)!.LicensePlate,
                Price = _repository!.GetById(car_id)!.Price
            };

            //Updated car
            Car? carToUpdate = new Car { Model = "BMW - 5 series", LicensePlate = "NT45641", Price = 600000};

            Car? updatedCar = _repository!.Update(car_id, carToUpdate);
            Assert.AreNotSame(car, updatedCar, "Are the same");

            Car? nullCar = _repository!.Update(10, carToUpdate);
            Assert.IsNull(nullCar);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _repository = null;
        }
    }
}