using Contracts.IServices;
using Entities.Data;
using Entities.Models.CategoryClass;
using Entities.Models.ManufacturesClass;
using Entities.Models.ParentCatgoriesClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentcategory
{
    public class ManufacturerRepo : IManufactures
    {
        private readonly DataContext _dataContext;
        public ManufacturerRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Manufacturer>> GetManufacturer()
        {
            return await _dataContext.Manufacturers.ToListAsync();
        }
        public async Task<Manufacturer> GetManufacturerId(int Id)
        {
            return await _dataContext.Manufacturers.FirstOrDefaultAsync(e => e.ManufacturerId == Id);
        }
        public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
        {
            var result = await _dataContext.Manufacturers.AddAsync(manufacturer);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Manufacturer> UpdateManufacturer(Manufacturer manufacturer)
        {
            var result = await _dataContext.Manufacturers
                .FirstOrDefaultAsync(e => e.ManufacturerId == manufacturer.ManufacturerId);

            if (result != null)
            {
                result.ManufacturerName = manufacturer.ManufacturerName;
                result.MDescription = manufacturer.MDescription;
                result.CreatedAt = manufacturer.CreatedAt;
                result.CreatedBy = manufacturer.CreatedBy;
                result.ModifiedAt = manufacturer.ModifiedAt;
                result.ModifiedBy = manufacturer.ModifiedBy;
                result.IsDeleted = manufacturer.IsDeleted;



                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteManufacturer(int Id)
        {
            var result = await _dataContext.Manufacturers
                .FirstOrDefaultAsync(e => e.ManufacturerId == Id);
            if (result != null)
            {
                _dataContext.Manufacturers.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<Manufacturer>> GetmanufacturerByValue(string name)
        {
            var query = from value in _dataContext.Manufacturers
                        where value.ManufacturerName == name
                        select value;

            return query;
        }
    }
}
