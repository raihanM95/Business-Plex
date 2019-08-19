using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class PurchaseDetails
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ManufacturedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public decimal MRP { get; set; }

        public string Remarks { get; set; }

        public int PurchaseSupplierId { get; set; }
        public PurchaseSupplier PurchaseSupplier { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
