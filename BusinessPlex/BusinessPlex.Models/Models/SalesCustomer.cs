using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class SalesCustomer
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int LoyaltyPoint { get; set; }

        [Required]
        public decimal PayableAmounth { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
