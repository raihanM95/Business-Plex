using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
