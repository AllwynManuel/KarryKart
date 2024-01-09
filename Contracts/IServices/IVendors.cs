using Entities.Models.ProductClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IVendors
    {
        Task<IEnumerable<Vendors>> GetVendors();
        Task<Vendors> GetVendorsId(int VendorsId);
        Task<Vendors> AddVendors(Vendors Vendors);
        Task<Vendors> UpdateVendors(Vendors Vendors);
        Task DeleteVendors(int VendorsId);
    }
}
