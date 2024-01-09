using Entities.Models.ProductClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IDiscount
    {
        Task<IEnumerable<Discount>> GetDiscount();
        Task<Discount> GetDiscountId(int discountId);
        Task<Discount> AddDiscount(Discount discount);
        Task<Discount> UpdateDiscount(Discount discount);
        Task DeleteDiscount(int discountId);
    }
}
