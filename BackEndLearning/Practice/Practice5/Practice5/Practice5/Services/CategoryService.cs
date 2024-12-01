using Microsoft.EntityFrameworkCore;
using Practice5.IServices;
using Practice5.Models;

namespace Practice5.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MoocDBContext _moocDBContext;
        public CategoryService(MoocDBContext moocDBContext)
        {
            this._moocDBContext = moocDBContext;
        }

        public Category Add(Category category)
        {
            this._moocDBContext.Categories.Add(category);
            this._moocDBContext.SaveChanges();
            return category;
        }

        public List<Category> GetCategories()
        {
            #region Query expression
            var categories = from category in this._moocDBContext.Categories
                             select category;
            return categories.ToList();
            #endregion

            #region Lambda expression
            //var categories = this._moocDBContext.Categories.ToList();
            //return categories;
            #endregion
        }

        public Category? GetCategoryByName(string name)
        {
            # region Lambda expression
            return this._moocDBContext.Categories.FirstOrDefault(x => x.CategoryName == name);
            #endregion

            #region Query expression
            //var categories = from category in this._moocDBContext.Categories
            //               where category.CategoryName == name
            //               select category;
            //return categories.FirstOrDefault();
            #endregion
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var updateCategory = await this._moocDBContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (updateCategory != null)
            {
                updateCategory.CategoryName = category.CategoryName;
                updateCategory.CategoryLevel = category.CategoryLevel;
                updateCategory.ParentId = category.ParentId;

                await this._moocDBContext.SaveChangesAsync();
                return updateCategory;
            }
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deleteCategory = await this._moocDBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteCategory != null)
            {
                this._moocDBContext.Categories.Remove(deleteCategory);
                return await this._moocDBContext.SaveChangesAsync() > 0; //how many entities(rows) were affected
            }
            return false;
        }
    }
}
