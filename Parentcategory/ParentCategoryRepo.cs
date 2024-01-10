using Contracts.IServices;
using Entities.Data;
using Entities.Models.ParentCatgoriesClass;
using Microsoft.EntityFrameworkCore;

namespace Parentcategory
{
    public class ParentCategoryRepo : IParentCategory
    {
        private readonly DataContext _dataContext;
        public ParentCategoryRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Parent_Catg>> GetParentCat()
        {
            return await _dataContext.Parent_Catgs.ToListAsync();
        }
        public async Task<Parent_Catg> GetParentCatId(int Id)
        {
            return await _dataContext.Parent_Catgs.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Parent_Catg> AddParentCat(Parent_Catg parent_Catg)
        {
            var result = await _dataContext.Parent_Catgs.AddAsync(parent_Catg);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Parent_Catg> UpdateParentCat(Parent_Catg parent_Catg)
        {
            var result = await _dataContext.Parent_Catgs
                .FirstOrDefaultAsync(e => e.Id == parent_Catg.Id);

            if (result != null)
            {
                result.Parent_Catg_Name = parent_Catg.Parent_Catg_Name;
                result.Description = parent_Catg.Description;
                result.parentCategories = parent_Catg.parentCategories;
                result.CreatedAt = parent_Catg.CreatedAt;
                result.CreatedBy = parent_Catg.CreatedBy;
                result.ModifiedAt = parent_Catg.ModifiedAt;
                result.ModifiedBy = parent_Catg.ModifiedBy;
                result.IsDeleted = parent_Catg.IsDeleted;


                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteParentCat(int Id)
        {
            var result = await _dataContext.Parent_Catgs
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.Parent_Catgs.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task<IQueryable<Parent_Catg>> GetParentCategoryByValue(string name)
        {

            var query = from value in _dataContext.Parent_Catgs
                        where value.Parent_Catg_Name == name || value.CreatedBy == name
                        select value;

            return query;
        }

    }
}
