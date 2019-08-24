using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductsView = new List<ProductViewModel>();
        }
        public int ProductId { get; set; }

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
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public decimal PreviousCostPrice { get; set; }
        public decimal PreviousMRP { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "CP(TK)")]
        public decimal TotalCostPrice { get; set; }

        [Display(Name = "Sale(TK)")]
        public decimal SalesPrice { get; set; }

        [Display(Name = "Profit(TK)")]
        public decimal Profit { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public List<ProductViewModel> ProductsView { get; set; }
        public List<Product> Products { get; set; }
    }
}