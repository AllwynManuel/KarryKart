using Contracts.IServices;
using Entities.Data;
using Entities.Models.ProductClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentcategory
{
    public class DiscountRepo : IDiscount
    {
        private readonly DataContext _dataContext;
        public DiscountRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Discount>> GetDiscount()
        {
            return await _dataContext.Discounts.ToListAsync();
        }
        public async Task<Discount> GetDiscountId(int Id)
        {
            return await _dataContext.Discounts.FirstOrDefaultAsync(e => e.DiscountID == Id);
        }
        public async Task<Discount> AddDiscount(Discount discount)
        {
            var result = await _dataContext.Discounts.AddAsync(discount);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Discount> UpdateDiscount(Discount discount)
        {
            var result = await _dataContext.Discounts
                .FirstOrDefaultAsync(e => e.DiscountID == discount.DiscountID);

            if (result != null)
            {
                result.Discount_Name = discount.Discount_Name;
                result.Discount_Percent = discount.Discount_Percent;
                result.Discount_Type = discount.Discount_Type;
                result.Start_Date = discount.Start_Date;
                result.End_Date = discount.End_Date;
                result.CreatedAt = discount.CreatedAt;
                result.CreatedBy = discount.CreatedBy;
                result.ModifiedAt = discount.ModifiedAt;
                result.ModifiedBy = discount.ModifiedBy;
                result.IsDeleted = discount.IsDeleted;



                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteDiscount(int Id)
        {
            var result = await _dataContext.Discounts
                .FirstOrDefaultAsync(e => e.DiscountID == Id);
            if (result != null)
            {
                _dataContext.Discounts.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
