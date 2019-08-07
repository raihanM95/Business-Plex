using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPlex.Models
{
    public class SupplierViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please enter Code")]
        [StringLength(10, MinimumLength = 3)]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Please enter Contact No")]
        public string Contact { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public List<Supplier> Suppliers { get; set; }
    }
}