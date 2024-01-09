using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.ParentCatgoriesClass;
using Entities.Models.ProductClass;

namespace Entities.Models.CategoryClass
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int Parent_CatgId { get; set; }
        public Parent_Catg Parent_Catg { get; set; }
        public int TaxId { get; set; }
        public Tax tax { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
