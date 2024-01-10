using Contracts.IServices;
using Entities.Data;
using Entities.Models.Enums;
using Entities.Models.ParentCatgoriesClass;
using Entities.Models.ProductClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentcategory
{

    public class InventoryRepository : IInventory
        {
            private readonly DataContext appDbContext;

            public InventoryRepository(DataContext appDbContext)
            {
                this.appDbContext = appDbContext;
            }

            public async Task<IEnumerable<Inventory>> GetInventory()
            {
                return await appDbContext.Inventory.ToListAsync();
            }

            public async Task<Inventory> GetInventorybyId(int Id)
            {
                return await appDbContext.Inventory
                    .FirstOrDefaultAsync(p => p.Id == Id);
            }

            public async Task<Inventory> AddInventory(Inventory inventory)
            {
                var result = await appDbContext.Inventory.AddAsync(inventory);
                await appDbContext.SaveChangesAsync();
                return result.Entity;
            }

            public async Task<Inventory> UpdateInventory(Inventory inventory)
            {
                var result = await appDbContext.Inventory
                    .FirstOrDefaultAsync(p => p.Id == inventory.Id);

                if (result != null)
                {

                    result.inventoryMethodEnum = inventory.inventoryMethodEnum;
                    result.Stockquantity = inventory.Stockquantity;
                    result.warehouse = inventory.warehouse;
                    result.MultipleWarehouse = inventory.MultipleWarehouse;
                    result.Displayavailability = inventory.Displayavailability;
                    result.Minimumstockqty = inventory.Minimumstockqty;
                    result.lowstockactivityenum = inventory.lowstockactivityenum;
                    result.Notifyforqtybelow = inventory.Notifyforqtybelow;
                    result.backordersbelow = inventory.backordersbelow;
                    result.Allowbackinstocksubscriptions = inventory.Allowbackinstocksubscriptions;
                    result.productavailabilityrange = inventory.productavailabilityrange;
                    result.Minimumcartqty = inventory.Minimumcartqty;
                    result.Maximumcartqty = inventory.Maximumcartqty;
                    result.Allowedquantities = inventory.Allowedquantities;
                    result.Notreturnable = inventory.Notreturnable;
                    result.CreatedAt = inventory.CreatedAt;
                    result.CreatedBy = inventory.CreatedBy;
                    result.ModifiedAt = inventory.ModifiedAt;
                    result.ModifiedBy = inventory.ModifiedBy;
                    result.IsDeleted = inventory.IsDeleted;


                await appDbContext.SaveChangesAsync();

                    return result;
                }
                return null;
            }

            public async Task<Inventory> DeleteInventory(int Id)
            {
                var result = await appDbContext.Inventory
                    .FirstOrDefaultAsync(p => p.Id == Id);
                if (result != null)
                {
                    appDbContext.Inventory.Remove(result);
                    await appDbContext.SaveChangesAsync();

                }
                return result;

            }
        public Task<IQueryable<Inventory>> SearchbyWareHouse(WarehouseEnum status)
        {
            var result = appDbContext.Inventory.
                Where(v => v.warehouse == status);

            return Task.FromResult(result.AsQueryable());
        }
    }

}
