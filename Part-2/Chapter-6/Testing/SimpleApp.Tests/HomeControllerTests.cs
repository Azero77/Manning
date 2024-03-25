using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void SameList() 
        {
            //Arrange

            Product[] tests = new Product[]
                {new(){Name = "Kayak" , Price = 275M },
                new(){Name = "LifeJacket" , Price = 48.95M },
                new(){Name = "Anas" , Price = 200M }, };
            
            var controller = new HomeController();
            var mock = new Mock<IDataSource>();
            mock.SetUpGet(m => m.Products).Returns(tests);
            controller.dataSource = mock.Object;

            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product> ?? Enumerable.Empty<Product>();

            //Assert
            Assert.Equal(model, tests,Comparer.Get((Product? p1, Product? p2) =>
            {
                return p1?.Name == p2?.Name && p1?.Price == p2?.Price;
            }));
            
        }
    }

    /*class FakeDataSource : IDataSource
    {
        private IEnumerable<Product> _products;
        public FakeDataSource(Product[] products) 
        {
            _products = products;
        }
        public IEnumerable<Product> Products { get => _products; }
    }*/
}
