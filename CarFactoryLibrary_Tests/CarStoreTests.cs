using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarStoreTests
    {
        CarStore store;
        public CarStoreTests()
        {
            store = new CarStore();
        }
        [Fact]
        public void AddCar_AddToyota_CollectionNotEmpty()
        {
            // Arrange
            Toyota toyota = new Toyota();
            BMW bMW = new BMW();

            // Act
            store.AddCar(toyota);

            // Assert
            Assert.NotEmpty(store.cars);

            // value equality
            Assert.Contains(toyota, store.cars);
            Assert.Contains(bMW, store.cars);

            //Assert.Collection() => Lab Task
        }

        [Fact]
        [Trait("Author", "Mohamed Kamal")]
        public void AddCars_AddMultipleCars_CheckAllNewCarsIsStopped() // Using Collection
        {
            // Arrange
            Toyota toyota = new Toyota();
            BMW bMW = new BMW();
            List<Car> cars = new List<Car> { toyota, bMW };

            // Act
            store.AddCars(cars);

            // Assert
            Assert.Collection(store.cars,
                car => Assert.True(car.drivingMode == DrivingMode.Stopped),
                car => Assert.True(car.drivingMode == DrivingMode.Stopped)
                );
        }

        [Fact]
        [Trait("Author", "Mohamed Kamal")]
        public void AddCars_AddMultipleCars_CheckAllNewCarsVelocity0() // Using All
        {
            // Arrange
            Toyota toyota = new Toyota();
            BMW bMW = new BMW();
            List<Car> cars = new List<Car> { toyota, bMW };

            // Act
            store.AddCars(cars);

            // Assert
            Assert.All(store.cars, car => Assert.Equal(0, car.velocity));
        }
    }
}
