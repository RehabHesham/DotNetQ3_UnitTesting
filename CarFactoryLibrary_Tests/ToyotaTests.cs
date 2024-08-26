using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    // class for testing
    // must be public
    public class ToyotaTests
    {
        //in xunit we have two attributes for test methods
        //[Fact]   => when test Method have no parameters
        //[Theory] => when test Method needs parameters

        [Fact]
        public void IsStopped_Velocity0_true()
        {
            // Arrange  => prepare objects and data
            Toyota toyota = new Toyota();

            // Act => Execution of function
           bool actualResult =  toyota.IsStopped();

            // Boolean Assert
            Assert.True(actualResult);
        }
        [Fact]
        public void IsStopped_Velocity10_false() {
            // Arrange  => prepare objects and data
            Toyota toyota = new Toyota();
            toyota.velocity = 10;

            // Act => Execution of function
            bool actualResult = toyota.IsStopped();

            // Boolean Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void IncreaseVelocity_Velocitoy10Add20_velocitoy30()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 10;
            toyota.drivingMode = DrivingMode.Backward;

            // Act 
            toyota.IncreaseVelocity(20);

            // Numeric Assert
            Assert.Equal(30, toyota.velocity);
            Assert.Equal(DrivingMode.Forward.ToString(), toyota.drivingMode.ToString());
            //Assert.NotEqual();

            Assert.InRange(toyota.velocity, 10, 30);
            //Assert.NotInRange();

            Assert.True(toyota.velocity > 10);
        }

        [Theory]
        [InlineData(10,5,15)]
        [InlineData(80,20,100)]
        public void IncreaseVelocity_useInlineData_FindInlineOutput
            (float intialVelocity, float increment, float result)
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = intialVelocity;
            toyota.drivingMode = DrivingMode.Backward;

            // Act 
            toyota.IncreaseVelocity(increment);

            // Numeric Assert
            Assert.Equal(result, toyota.velocity);
            Assert.Equal(DrivingMode.Forward.ToString(), toyota.drivingMode.ToString());
            //Assert.NotEqual();

            Assert.InRange(toyota.velocity, intialVelocity, result);
            //Assert.NotInRange();

            Assert.True(toyota.velocity > intialVelocity);
        }
        [Fact]
        public void GetDirection_Forward_Forward()
        {
            // Arrange
            Toyota toyota = new Toyota
            {
                velocity = 10,
                drivingMode = DrivingMode.Forward
            };

            // Act
            string result = toyota.GetDirection();

            // string Assert
            Assert.Equal("Forward", result);
            Assert.Equal("Forward", result,ignoreCase:true);

            Assert.StartsWith("F", result);
            Assert.EndsWith("d", result);
            Assert.Contains("wa", result);
            Assert.Matches("F[a-z]{6}", result);
        }
    }
}
