using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Entities.Models.CategoryClass;
using Contracts.IServices;

namespace Categorynamespace
{
    public class CategoryRepo : ICategory
    {
        private readonly DataContext _dataContext;
        public CategoryRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _dataContext.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryId(int Id)
        {
            return await _dataContext.Categories.FirstOrDefaultAsync(e => e.CategoryId == Id);
        }
        public async Task<Category> AddCategory(Category category)
        {
            var result = await _dataContext.Categories.AddAsync(category);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await _dataContext.Categories
                .FirstOrDefaultAsync(e => e.CategoryId== category.CategoryId);

            if (result != null)
            {
                result.CategoryName = category.CategoryName;
                result.CategoryDescription = category.CategoryDescription;
                result.Parent_Catg = category.Parent_Catg;
                result.CreatedAt = category.CreatedAt;
                result.CreatedBy = category.CreatedBy;
                result.ModifiedAt = category.ModifiedAt;
                result.ModifiedBy = category.ModifiedBy;
                result.IsDeleted = category.IsDeleted;
                


                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteCategory(int Id)
        {
            var result = await _dataContext.Categories
                .FirstOrDefaultAsync(e => e.CategoryId == Id);
            if (result != null)
            {
                _dataContext.Categories.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
