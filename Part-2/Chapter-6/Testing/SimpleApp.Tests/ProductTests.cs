using Xunit;
using SimpleApp.Models;

namespace SimpleApp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeName()
        {
            //Arrange
            //Set the conditions to start acting
            Product p = new() { Name = "Anas", Price = 200m };

            //Act
            //making assumption that will be tested in Assert
            p.Name = "Azero";
            //Assert
            Assert.Equal("Azero", p?.Name ?? "");

        }

        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            //Set the conditions to start acting
            Product p = new() { Name = "Anas", Price = 200m };

            //Act
            //making assumption that will be tested in Assert
            p.Price = 100M;
            //Assert
            Assert.Equal(100m, p.Price);

        }
    }
}
