using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductClass
{
    public class Rental
    {
        public int Id { get; set; }
        public bool IsRental { get; set; }
        public int RentalPeriodLength { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public RentalPeriodEnum RentalPeriod { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
    public enum RentalPeriodEnum
    {
        Days,
        Weeks,
        Months,
        Years
    }
}
