using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Models
{
    public class SalesViewModel
    {
        public int SalesCustomerId { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> CustomerSelectListItems { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please select Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Loyalty point")]
        [Required(ErrorMessage = "Please select Customer")]
        public int LoyaltyPoint { get; set; }

        [Display(Name = "Payable Amounth(Tk)")]
        [Required(ErrorMessage = "Please enter Payable Amounth")]
        public decimal PayableAmounth { get; set; }

        public int SalesDetailsId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductSelectListItems { get; set; }

        [Display(Name = "Available Quantity")]
        //[Required]
        public int AvailableQuantity { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please enter Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Unit Price(Tk)")]
        [Required(ErrorMessage = "Please enter Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Total Price(Tk)")]
        [Required]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Grand Total(Tk)")]
        //[Required]
        public decimal GrandTotal { get; set; }

        [Display(Name = "Discount(%)")]
        //[Required]
        public decimal Discount { get; set; }

        [Display(Name = "Discount Amounth(Tk)")]
        [Required(ErrorMessage = "Please enter Discount Amounth")]
        public decimal DiscountAmounth { get; set; }

        public List<SalesViewModel> SalesViewModels { get; set; }
        public ICollection<SalesDetails> SalesDetails { get; set; }
    }
}