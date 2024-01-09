using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ParentCatgoriesClass
{
    public class Parent_Catg
    {
        public int Id { get; set; }
        public string Parent_Catg_Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public ParentCatgories parentCategories { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }



    }
}
