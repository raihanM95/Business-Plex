using System;
using System.Collections.Generic;
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

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please enter Code")]
        [StringLength(5, MinimumLength = 3)]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Reorder level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public string Search { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
    }
}
