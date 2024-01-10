using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.ParentCatgoriesClass;

namespace Contracts.IServices
{
    public interface IParentCategory
    {
        Task<IEnumerable<Parent_Catg>> GetParentCat();
        Task<Parent_Catg> GetParentCatId(int parcatgId);
        Task<Parent_Catg> AddParentCat(Parent_Catg parcatg);
        Task<Parent_Catg> UpdateParentCat(Parent_Catg parcatg);
        Task DeleteParentCat(int parcatgId);
        Task<IQueryable<Parent_Catg>> GetParentCategoryByValue(string name);
    }
}
