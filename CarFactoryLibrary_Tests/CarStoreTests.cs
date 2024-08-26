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
        [Fact]
        public void AddCar_AddToyota_CollectionNotEmpty()
        {
            // Arrange
            CarStore store = new CarStore();
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
    }
}
