using Entities.Models.ProductClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IShipping
    {
        Task<IEnumerable<Shipping>> GetShipping();
        Task<Shipping> GetShippingId(int ShippingId);
        Task<Shipping> AddShipping(Shipping Shipping);
        Task<Shipping> UpdateShipping(Shipping Shipping);
        Task DeleteShipping(int ShippingId);
    }
}
