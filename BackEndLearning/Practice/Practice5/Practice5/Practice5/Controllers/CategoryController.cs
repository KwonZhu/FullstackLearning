using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice5.IServices;
using Practice5.Models;
using Practice5.ViewModels;

namespace Practice5.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        public Category AddCategory(AddCategoryInput input)
        {
            Category category = new Category();
            category.CategoryName = input.CategroyName;
            category.CategoryLevel = input.CategoryLevel;
            category.ParentId = input.ParentId;
            var result = this._categoryService.Add(category);
            return result;
        }

        [HttpGet]
        public List<CategoryOutput> GetCategory()
        {
            var result = this._categoryService.GetCategories();
            List<CategoryOutput> resultList = new List<CategoryOutput>();
            foreach (var category in result)
            {
                CategoryOutput categoryOutput = new CategoryOutput();
                categoryOutput.CategroyName = category.CategoryName;
                categoryOutput.CategoryLevel = category.CategoryLevel;
                categoryOutput.ParentId = category.ParentId;
                resultList.Add(categoryOutput);
            }
            return resultList;
        }

        [HttpPut]
        public async Task<CategoryOutput> UpdateCategoryAsync(UpdateCategoryInput input)
        {
            Category category = new Category();
            category.CategoryName = input.CategroyName;
            category.CategoryLevel = input.CategoryLevel;
            category.ParentId = input.ParentId;
            var result = await this._categoryService.UpdateCategoryAsync(category);

            CategoryOutput categoryOutput = new CategoryOutput();
            categoryOutput.CategroyName = result.CategoryName;
            categoryOutput.CategoryLevel = result.CategoryLevel;
            categoryOutput.ParentId = result.ParentId;
            return categoryOutput;
        }

        [HttpDelete]
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            bool result = await this._categoryService.DeleteCategoryAsync(id);
            return result;
        }
    }
}
