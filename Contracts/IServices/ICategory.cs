using Entities.Models.CategoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryId(int categoryId);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
    }
}
