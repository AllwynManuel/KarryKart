using Entities.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductClass
{
    public partial class Inventory
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public InventoryMethodEnum inventoryMethodEnum { get; set; }
        public int Stockquantity {  get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public WarehouseEnum warehouse { get; set; }
        public bool MultipleWarehouse { get; set; }
        public bool Displayavailability { get; set; }
        public int Minimumstockqty { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Lowstockactivityenum lowstockactivityenum { get; set; }
        public int Notifyforqtybelow { get; set; }
        public BackordersEnum backordersbelow { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public bool Allowbackinstocksubscriptions { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public ProductavailabilityrangeEnum productavailabilityrange { get; set; }
        public int Minimumcartqty { get; set; }
        public int Maximumcartqty {  get; set; }
        public string Allowedquantities { get; set; }
        public bool Notreturnable { get; set; }
        public bool Allowonlyexistingattributecombinations { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        

    }
    
}
