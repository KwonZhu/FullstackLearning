using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Practice5.Models;
using Practice5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractice5.ServiceTest
{
    public class APICategoryServiceTest
    {
        private List<Category> LoadCategoriesFromJson(string FilePath)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                var catrgoriesStringValue = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Category>>(catrgoriesStringValue); //convert the json string into a List<Category>
            }
        }

        private string GetFilePath(string relativePath)
        {
            var fullPath = Path.Combine(AppContext.BaseDirectory, relativePath); //AppContext.BaseDirectory: Returns the path where the binaries (bin\Debug\net8.0) are located.
            return fullPath;
        }

        [Fact]
        public async Task GetCategories_Should_Return_AllCategories() // return a Task since some operations (like database calls) may be asynchronous
        {   
            //Arrange
            // Use the helper method to get the full path
            var filePath = GetFilePath(@"MockData\categories.json");
            var categories = LoadCategoriesFromJson(filePath);

            var options = new DbContextOptionsBuilder<MoocDBContext>()
                .UseInMemoryDatabase("TestDatabase_1") //To solve same db conflicts between test cases
                .Options; //finalizes the configuration and creates DbContextOptions object(options), which is passed to the MDBContext to tell how to connect to db

            //Act
            using (var context = new MoocDBContext(options)) //creates a new instance of the MDBContext configured to use the in-memory database
            {
                context.Categories.AddRange(categories); //Adds all the loaded categories to the Categories DbSet 
                context.SaveChanges();
            }

            using (var context = new MoocDBContext(options)) //creates another new instance. using: dispose MDBContext instance after use
            {
                var service = new CategoryService(context);
                var result = service.GetCategories(); //await is no needed if it is not Async()

                //Assert
                Assert.NotNull(result);
                Assert.Contains(result, c => c.CategoryName == "Programming"); //For each category c in the collection result, it checks whether c.CategoryName equals "Programming"
                Assert.Equal("Programming", result[0].CategoryName);
                Assert.Equal(context.Categories.Count(), result.Count);

            }
        }

        [Fact]
        public async Task Add_Should_Return_AddedCategory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MoocDBContext>()
                .UseInMemoryDatabase("TestDatabase_2")
                .Options;

            var newCategory = new Category
            {
                Id = 1,
                CategoryName = "DevOps",
                CategoryLevel = 1,
                ParentId = null
            };

            //Act
            using (var context = new MoocDBContext(options)) 
            {
                var service= new CategoryService(context);
                var result = service.Add(newCategory);

                //Assert
                Assert.NotNull(result);
                Assert.Equal("DevOps", result.CategoryName);
                Assert.Equal(1, context.Categories.Count());
            }
        }

        [Fact]
        public async Task GetCategoryByName_Should_Return_CorrectCategory()
        {
            //Arrange
            var filePath = GetFilePath(@"MockData\categories.json");
            var categories = LoadCategoriesFromJson(filePath);

            var options = new DbContextOptionsBuilder<MoocDBContext>()
                .UseInMemoryDatabase("TestDatabase_3")
                .Options;

            //Act
            using (var context = new MoocDBContext(options))
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            using (var context = new MoocDBContext(options))
            {
                var service = new CategoryService(context);
                var result =  service.GetCategoryByName("Programming");

                //Assert
                Assert.NotNull (result);
                Assert.True(result.Id == 1);
            }
        }

        
    }
}


