using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Practice5.Controllers;
using Practice5.IServices;
using Practice5.Models;
using Practice5.Services;
using Practice5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var newCategoryInput = new AddCategoryInput
            {
                CategroyName = "Technology",
                CategoryLevel = 1,
                ParentId = null
            };

            // Act
            var result = _categoryController.AddCategory(newCategoryInput);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newCategoryInput.CategroyName, result.CategoryName);
            Assert.Equal(newCategoryInput.CategoryLevel, result.CategoryLevel);
            Assert.Equal(newCategoryInput.ParentId, result.ParentId);
        }

       
    }

}
