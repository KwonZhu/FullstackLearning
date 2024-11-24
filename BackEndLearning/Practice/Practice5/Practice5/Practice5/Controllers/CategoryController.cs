using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice5.IServices;
using Practice5.Models;
using Practice5.ViewModels;

namespace Practice5.Controllers
{
    /// <summary>
    /// API Controller for managing categories.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryService">Service for category management.</param>
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="input">The input model for adding a category.</param>
        /// <returns>The newly added category.</returns>
        //a <param> element for the parameter, and a <returns> element to document the return value
        [HttpPost]
        public Category AddCategory(AddCategoryInput input)
        {
            Category category = new Category();
            category.CategoryName = input.CategoryName;
            category.CategoryLevel = input.CategoryLevel;
            category.ParentId = input.ParentId;
            var result = this._categoryService.Add(category);
            return result;
        }

        /// <summary>
        /// Gets the list of all categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        [HttpGet]
        public List<CategoryOutput> GetCategory()
        {
            var result = this._categoryService.GetCategories();
            List<CategoryOutput> resultList = new List<CategoryOutput>();
            foreach (var category in result)
            {
                CategoryOutput categoryOutput = new CategoryOutput();
                categoryOutput.CategoryName = category.CategoryName;
                categoryOutput.CategoryLevel = category.CategoryLevel;
                categoryOutput.ParentId = category.ParentId;
                resultList.Add(categoryOutput);
            }
            return resultList;
        }

        /// <summary>
        /// Updates an existing category asynchronously.
        /// </summary>
        /// <param name="input">The input model for updating a category.</param>
        /// <returns>The updated category.</returns>
        [HttpPut]
        public async Task<CategoryOutput> UpdateCategoryAsync(UpdateCategoryInput input)
        {
            Category category = new Category();
            category.CategoryName = input.CategoryName;
            category.CategoryLevel = input.CategoryLevel;
            category.ParentId = input.ParentId;
            var result = await this._categoryService.UpdateCategoryAsync(category);

            CategoryOutput categoryOutput = new CategoryOutput();
            categoryOutput.CategoryName = result.CategoryName;
            categoryOutput.CategoryLevel = result.CategoryLevel;
            categoryOutput.ParentId = result.ParentId;
            return categoryOutput;
        }

        /// <summary>
        /// Deletes a category by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            bool result = await this._categoryService.DeleteCategoryAsync(id);
            return result;
        }
    }
}
