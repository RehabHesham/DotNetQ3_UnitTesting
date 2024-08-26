using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using CarFactoryAPI_Tests.Stups;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryAPI_Tests.ServicesTests
{
    public class OwnerServiceTests : IDisposable
    {
        // 1- create mock for dependencies
        Mock<ICarsRepository> carRepoMock;
        Mock<IOwnersRepository> ownerRepoMock;
        CashService cashService;
        // 4- use Mock object as fake depedencey
        OwnersService ownersService;

        private readonly ITestOutputHelper helper;

        public OwnerServiceTests(ITestOutputHelper helper)
        {
            this.helper = helper;
            helper.WriteLine("Test setup");
            // 1- create mock for dependencies
            carRepoMock = new();
            ownerRepoMock = new();
            cashService = new CashService();
            // 4- use Mock object as fake depedencey
            ownersService = new(carRepoMock.Object, ownerRepoMock.Object, cashService);

        }
        [Fact]
        [Trait("Author", "Ali")]
        [Trait("Priority", "2")]


        public void BuyCar_CarIdNotExist_NotExist()
        {
            // Arrange
            //FactoryContext factoryContext = new FactoryContext(); ;
            
            //CarRepository carRepository = new(factoryContext);
            //OwnerRepository ownerRepository = new(factoryContext);
            CashService cashService = new();
            
            OwnersService ownersService = new(new CarRepositoryStup(),new OwnerReposirorystub(),cashService);

            BuyCarInput input = new()
            {
                CarId = 1,
                OwnerId = 2, 
                Amount = 1000
            };

            // Act
            string result = ownersService.BuyCar(input);

            // Assert
            Assert.Contains("exist", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        [Trait("Author", "Ahmed")]
        [Trait("Priority", "2")]

        public void BuyCar_OwnerNotExist_Notexist()
        {
            helper.WriteLine("Test1");
            // Arrange 
            
            // 2- prepare mocking data
            Owner owner = null;
            Car car = new Car() { Id = 5, VIN = "545454", Price = 1000, Type = CarType.Audi, Velocity = 100 };

            // 3- setup called methods
            carRepoMock.Setup(o => o.GetCarById(5)).Returns(car);
            ownerRepoMock.Setup(o => o.GetOwnerById(2)).Returns(owner);

            
            BuyCarInput buyCarInput = new()
            {
                CarId = 1,
                OwnerId = 2,
                Amount = 1000
            };
            // Act

            string result = ownersService.BuyCar(buyCarInput);
            // Assert

            Assert.Contains("exist", result, StringComparison.OrdinalIgnoreCase);

        }
        [Fact]
        [Trait("Author","Ali")]
        [Trait("Priority", "5")]

        public void BuyCar_CarWithOwner_Carsold()
        {
            helper.WriteLine("Test2");
            // arrange
            
            Car car = new Car() { Id = 5, VIN = "454564", Price = 1000, Velocity = 100, Type = CarType.BMW, OwnerId = 5, Owner = new Owner() { Id = 5 }  };

            carRepoMock.Setup(o => o.GetCarById(5)).Returns(car);

            BuyCarInput buyCarInput = new() { CarId = 5, OwnerId = 6, Amount = 500 };
            // act 
            string result = ownersService.BuyCar(buyCarInput);
            // assery
            Assert.Contains("sold", result);
        }

        public void Dispose()
        {
            helper.WriteLine("test clean up");
        }
    }
}
