using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class Product
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public string Image { get; set; }
        
        public int ReorderLevel { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public decimal TotalCostPrice { get; set; }
        [NotMapped]
        public decimal SalesPrice { get; set; }
        [NotMapped]
        public decimal Profit { get; set; }
    }
}
