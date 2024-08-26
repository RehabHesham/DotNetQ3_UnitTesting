using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarFactoryTests
    {
        [Fact]
        public void NewCar_AskForToyota_GetToyotaObject()
        {
            // Arrange
            Toyota toyota = new Toyota();


            // Act
            Car? car = CarFactory.NewCar(CarTypes.Toyota);

            // Assert

            // value equality
            Assert.Equal<Car>(car, toyota);

            // refrence equality
            //Assert.Same(car, toyota);
            Assert.NotSame(car, toyota);

            Assert.IsType<Toyota>(car);
            Assert.IsNotType<BMW>(car);

            Assert.IsAssignableFrom<Car>(car);
        }

        [Fact]
        public void NewCar_AskForAudi_null()
        {
            // Act
            Car? car = CarFactory.NewCar(CarTypes.Audi);

            // Assert
            Assert.Null(car);
        }

        [Fact]
        public void NewCar_AskforHonda_Exception()
        {
            // Arrange


            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act 
                Car? car = CarFactory.NewCar(CarTypes.Honda);
            });

            Assert.ThrowsAny<Exception>(() =>
            {
                // Act 
                Car? car = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
