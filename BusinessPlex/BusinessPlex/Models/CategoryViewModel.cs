using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessPlex.Models
{
    public class CategoryViewModel
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

        public List<Category> Categories { get; set; }
    }
}