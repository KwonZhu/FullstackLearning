using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Org.BouncyCastle.Crypto;
using Practice5.Controllers;
using Practice5.IServices;
using Practice5.Models;
using Practice5.Services;
using Practice5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestPractice5.ControllerTest
{
    public class CategoryControllerTest
    {
        private readonly CategoryController _categoryController;
        private readonly Mock<ICategoryService> _mockCategoryService;

        public CategoryControllerTest()
        {

            _mockCategoryService = new Mock<ICategoryService>();
            _categoryController = new CategoryController(_mockCategoryService.Object);
        }

        [Fact]
        public void AddCategory_Should_Add_NewCategory()
        {
            // Arrange
            var input = new AddCategoryInput
            {
                CategoryName = "Sample Category",
                CategoryLevel = 1,
                ParentId = null
            };

            _mockCategoryService.Setup(service => service.Add(It.IsAny<Category>()))
                                .Returns((Category c) => c);
            //It.IsAny<T>() acts as a placeholder, meaning the mock method will respond regardless of what specific object is passed, as long as it's of type T
            //lambda (Category c) => c to return the same object passed to the Add method
            //when the Add method of _mockCategoryService is called with any Category object, the mock will return the same object

            // Act
            var result = _categoryController.AddCategory(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.CategoryName, result.CategoryName);
            Assert.Equal(input.CategoryLevel, result.CategoryLevel);
            Assert.Equal(input.ParentId, result.ParentId);
            _mockCategoryService.Verify(service => service.Add(It.Is<Category>(c => c.CategoryName == input.CategoryName)), Times.Once);
            //Verify the `Add` method was called ONCE
            //with a Category object WHERE CategoryName == input.CategroyName.
            /*
            the Verify call performs a single verification but combines two checks:
            1. Argument Validation(It.Is<Category>(...)): Checks the parameter passed to the Add method.
            2. Invocation Count(Times.Once): Verifies the Add method was called the correct number of times.
            Moq allows combining argument validation and call count verification in one Verify statement
            */
        }

        [Fact]
        public void GetCategory_should_Return_ListOfCategories()
        {
            //Arrange
            var mockCategories = new List<Category>()
            {
                new Category { Id = 1, CategoryName = "Category 1", CategoryLevel = 1, ParentId = null },
                new Category { Id = 2, CategoryName = "Category 2", CategoryLevel = 2, ParentId = 1 }
            };

            _mockCategoryService.Setup(service => service.GetCategories()).Returns(mockCategories);

            //Act
            var result = _categoryController.GetCategory();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Category 1", result[0].CategoryName);
            Assert.Equal(1, result[0].CategoryLevel);
            Assert.Equal(mockCategories.Count(), result.Count());
            _mockCategoryService.Verify(service => service.GetCategories(), Times.Once());
        }

    }

}
