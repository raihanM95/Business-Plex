using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Models.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        public string ContactPerson { get; set; }

        public string Image { get; set; }
    }
}
