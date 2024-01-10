using Entities.Models.Enums;
using Entities.Models.ProductClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IInventory
    {
        Task<IEnumerable<Inventory>> GetInventory();
        Task<Inventory> GetInventorybyId(int Id);
        Task<Inventory> AddInventory(Inventory inventory);
        Task<Inventory> UpdateInventory(Inventory inventory);
        Task<Inventory> DeleteInventory(int Id);
        Task<IQueryable<Inventory>> SearchbyWareHouse(WarehouseEnum status);
    }
}

