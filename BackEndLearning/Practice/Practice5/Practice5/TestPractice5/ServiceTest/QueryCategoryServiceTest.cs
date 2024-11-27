using Microsoft.EntityFrameworkCore;
using Moq;
using Practice5.Models;
using Practice5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractice5.ServiceTest
{
    public class QueryCategoryServiceTest
    {
        //Reusable helper methods used to create mocks for different test cases
        private Mock<DbSet<Category>> CreateMockDbSet(IQueryable<Category> data)
        {
            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }

        private Mock<MoocDBContext> CreateMockContext(DbSet<Category> mockSet)
        {
            var mockContext = new Mock<MoocDBContext>(new DbContextOptions<MoocDBContext>());
            mockContext.Setup(c => c.Categories).Returns(mockSet);
            return mockContext;
        }

        [Fact]
        public void GetCategories_Should_Return_AllCategories()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category { Id = 1, CategoryName = "Math", CategoryLevel = 1 },
                new Category { Id = 2, CategoryName = "Science", CategoryLevel = 2 }
            }.AsQueryable();

            var mockSet = CreateMockDbSet(data);
            var mockContext = CreateMockContext(mockSet.Object);

            var service = new CategoryService(mockContext.Object);

            // Act
            var categories = service.GetCategories();

            // Assert
            Assert.Equal(2, categories.Count);
            Assert.Equal("Math", categories[0].CategoryName);
            Assert.Equal("Science", categories[1].CategoryName);
        }

        [Fact]
        public void Add_Should_Add_Category_To_DataBase()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            var newCategory = new Category { Id = 3, CategoryName = "History", CategoryLevel = 1 };

            // Act
            var addedCategory = service.Add(newCategory);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.Equal("History", addedCategory.CategoryName);
        }

        [Fact]
        public void GetCategoryByName_Should_Return_Category_With_MatchingName()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category { Id = 1, CategoryName = "Math", CategoryLevel = 1 },
                new Category { Id = 2, CategoryName = "Science", CategoryLevel = 2 }
            }.AsQueryable();

            var mockSet = CreateMockDbSet(data);
            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            // Act
            var category = service.GetCategoryByName("Math");

            // Assert
            Assert.NotNull(category);
            Assert.Equal("Math", category.CategoryName);
        }

        [Fact]
        public void GetCategoryByName_Should_Return_Null_When_NoMatching()
        {
            // Arrange
            var data = new List<Category>
            {
                new Category { Id = 1, CategoryName = "Math", CategoryLevel = 1 }
            }.AsQueryable();

            var mockSet = CreateMockDbSet(data);
            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            // Act
            var category = service.GetCategoryByName("History");

            // Assert
            Assert.Null(category);
        }
        [Fact]
        public async Task UpdateCategoryAsync_Should_Return_UpdatedCategory_When_Successed()
        {
            // Arrange
            var category = new Category { Id = 1, CategoryName = "Math", CategoryLevel = 1 };

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(category);

            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            var updatedCategory = new Category { Id = 1, CategoryName = "Advanced Math", CategoryLevel = 2 };

            // Act
            var result = await service.UpdateCategoryAsync(updatedCategory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Advanced Math", result.CategoryName);
            Assert.Equal(2, result.CategoryLevel);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task UpdateCategoryAsync_ReturnsSameCategory_WhenNotFound()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            var updatedCategory = new Category { Id = 1, CategoryName = "Advanced Math", CategoryLevel = 2 };

            // Act
            var result = await service.UpdateCategoryAsync(updatedCategory);

            // Assert
            Assert.Equal(updatedCategory, result);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Never);
        }

        [Fact]
        public async Task DeleteCategoryAsync_DeletesCategorySuccessfully()
        {
            // Arrange
            var category = new Category { Id = 1, CategoryName = "Math", CategoryLevel = 1 };

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(category);

            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            // Act
            var result = await service.DeleteCategoryAsync(1);

            // Assert
            Assert.True(result);
            mockSet.Verify(m => m.Remove(It.IsAny<Category>()), Times.Once);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ReturnsFalse_WhenCategoryNotFound()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = CreateMockContext(mockSet.Object);
            var service = new CategoryService(mockContext.Object);

            // Act
            var result = await service.DeleteCategoryAsync(1);

            // Assert
            Assert.False(result);
            mockSet.Verify(m => m.Remove(It.IsAny<Category>()), Times.Never);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Never);
        }
    }
}

