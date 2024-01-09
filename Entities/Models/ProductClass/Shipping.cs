using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductClass
{
    public class Shipping
    {
        public int Id { get; set; }
        public bool ShippingEnabled { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool FreeShipping { get; set; }
        public bool Shippingseperately { get; set; }
        public double AdditionalShippingCharges { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public DeliveryDate deliveryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
