using Moq;
using SportShop.Models;
using SportShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;


namespace SportShop.Tests
{
    public class ProductTests
    {
       
        [Fact]
        public void CanGetProductList_ReturnListOfProducts()
        {
            //Arrange
            Mock<IProductRepository> productMock = new Mock<IProductRepository>();
            productMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "Prod1"},
                new Product {ProductId = 2, Name = "Prod2"},
                new Product {ProductId = 3, Name = "Prod3"},
                new Product {ProductId = 4, Name = "Prod4"}
            }.AsQueryable<Product>());
            
            Mock<IManufacturerRepository> manufacturerMock = new Mock<IManufacturerRepository>();
            manufacturerMock.Setup(m => m.Manufacturers).Returns(new Manufacturer[] {
                new Manufacturer {ManufacturerId = 1, Name = "Avon"},
                new Manufacturer {ManufacturerId = 2, Name = "PJM"},
                new Manufacturer {ManufacturerId = 1, Name = "Valvex"}
            }.AsQueryable<Manufacturer>());


            //Act
            AdminController adminController = new AdminController(productMock.Object, manufacturerMock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(adminController.Index()).ToArray();


            //Assert
            Assert.Equal("Prod1", result[0].Name);
            Assert.Equal("Prod2", result[1].Name);
            Assert.Equal("Prod3", result[2].Name);
            Assert.Equal("Prod4", result[3].Name);
            Assert.Equal(4, result.Count());

        }

        [Fact]
        public void CanGetProductListByCategory_ReturnListOfProductSelectedByCategory()
        {
            //Arrange
            Mock<IProductRepository> productMock = new Mock<IProductRepository>();
            productMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "Prod1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "Prod2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "Prod3", Category = "Cat3"},
                new Product {ProductId = 4, Name = "Prod4", Category = "Cat4"},
                new Product {ProductId = 5, Name = "Prod5", Category = "Cat1"}

            }.AsQueryable<Product>());

            //Act
            ProductController productController = new ProductController(productMock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(productController.List("Cat1")).ToArray();

            //Assert
            Assert.Equal(2, result.Length);
            Assert.True("Cat1" == result[0].Category && "Prod1" == result[0].Name);
            Assert.True("Cat1" == result[1].Category && "Prod5" == result[1].Name);


        }


        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
