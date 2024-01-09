using Contracts.IServices;
using Entities.Data;
using Entities.Models.CategoryClass;
using Entities.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentcategory
{
    public class ProductRepo : IProduct
    {
        private readonly DataContext _dataContext;
        public ProductRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _dataContext.products.ToListAsync();
        }
        public async Task<Product> GetProductId(int Id)
        {
            return await _dataContext.products.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _dataContext.products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _dataContext.products
                .FirstOrDefaultAsync(e => e.Id == product.Id);

            if (result != null)
            {
                result.Name = product.Name;
                result.ShortDescription = product.ShortDescription;
                result.FullDescription = product.FullDescription;
                result.SKU = product.SKU;
                result.CategoryId = product.CategoryId;
                result.ManufacturerId = product.ManufacturerId;
                result.Published = product.Published;
                result.ProductTags = product.ProductTags;
                result.GTINNumber = product.GTINNumber;
                result.ManufacturerpartNumber = product.ManufacturerpartNumber;
                result.Showonhomepage = product.Showonhomepage;
                result.ProductType = product.ProductType;
                result.ProductTemplate = product.ProductTemplate;
                result.VisibleIndividualy = product.VisibleIndividualy;
                result.CustomerRoles = product.CustomerRoles;
                result.LimitedToStores = product.LimitedToStores;
                result.RequireotherProducts = product.RequireotherProducts;
                result.RequiredproductIDs = product.RequiredproductIDs;
                result.Automaticallyaddproductstocart = product.Automaticallyaddproductstocart;
                result.Allowcustomerreviews = product.Allowcustomerreviews;
                result.AvailableStartDate = product.AvailableStartDate;
                result.AvailableEndDate = product.AvailableEndDate;
                result.MarkAsNew = product.MarkAsNew;
                result.AdminComment = product.AdminComment;
                result.CreatedAt = product.CreatedAt;
                result.CreatedBy = product.CreatedBy;
                result.ModifiedAt = product.ModifiedAt;
                result.ModifiedBy = product.ModifiedBy;
                result.IsDeleted = product.IsDeleted;



                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteProduct(int Id)
        {
            var result = await _dataContext.products
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.products.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
