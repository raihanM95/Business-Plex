using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class PurchaseSupplier
    {
        public int ID { get; set; }

        [Required]
        public int InvoiceNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
