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
    public class ShippingRepo : IShipping
    {
        private readonly DataContext appDbContext;

        public ShippingRepo(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Shipping>> GetShipping()
        {
            return await appDbContext.Shippings.ToListAsync();
        }
        public async Task<Shipping> GetShippingId(int Id)
        {
            return await appDbContext.Shippings
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Shipping> AddShipping(Shipping shipping)
        {
            var result = await appDbContext.Shippings.AddAsync(shipping);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Shipping> UpdateShipping(Shipping shipping)
        {
            var result = await appDbContext.Shippings
                .FirstOrDefaultAsync(p => p.Id == shipping.Id);

            if (result != null)
            {




                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteShipping(int ShippingId)
        {
            var result = await appDbContext.Shippings
                .FirstOrDefaultAsync(p => p.Id == ShippingId);
            if (result != null)
            {
                appDbContext.Shippings.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
           

        }
    }
}
