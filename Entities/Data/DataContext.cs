using Entities.Models.CategoryClass;
using Entities.Models.ManufacturesClass;
using Entities.Models.ParentCatgoriesClass;
using Entities.Models.Product;
using Entities.Models.ProductClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class DataContext : DbContext
    {
        public DataContext() 
        {
        }
        public DataContext(DbContextOptions<DataContext>options):base(options) 
        {
                
        }
        public virtual DbSet<Parent_Catg> Parent_Catgs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Models.Product.Product> products { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<Models.ProductClass.Inventory> Inventory { get; set; }
        public virtual DbSet<GiftCard> GiftCards { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<Recurring_Product> RecurringProduct { get; set; }
        public virtual DbSet<DownloadableProduct> DownloadProduct { get; set; }
        public virtual DbSet<SEO> SEO { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=KarryKart;Integrated Security=True;TrustServerCertificate=True;");

    }
}
