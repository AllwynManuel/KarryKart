using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductClass
{
    public partial class Vendors
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }

        public string Company_name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public int Phone_number { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
