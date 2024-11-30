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
                return JsonConvert.DeserializeObject<List<Category>>(catrgoriesStringValue);
            }
        }

        [Fact]
        public async Task GetCategories_Should_Return_AllCategories()
        {
            var categories = LoadCategoriesFromJson("C:\\Users\\kwonz\\source\\repos\\fullstack23\\FullstackLearning\\BackEndLearning\\Practice\\Practice5\\Practice5\\TestPractice5\\MockData\\categories.json");

            var options = new DbContextOptionsBuilder<MoocDBContext>()
                .UseInMemoryDatabase("TestDatabase_1") //To solve same db conflicts, rename dbname
                .Options;

            using (var context = new MoocDBContext(options))
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            using (var context = new MoocDBContext(options))
            {
                var service = new CategoryService(context);
                var result = service.GetCategories();

                //Assert
                Assert.NotNull(result);
                Assert.Contains(result, c => c.CategoryName == "Programming");
                Assert.Equal("Programming", result[0].CategoryName);
                Assert.Equal(categories.Count, result.Count);

            }
        }

    }
}
