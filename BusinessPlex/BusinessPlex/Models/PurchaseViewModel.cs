using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Models
{
    public class PurchaseViewModel
    {
        //public int ID { get; set; }

        [Display(Name = "Invoice No")]
        [Required(ErrorMessage = "Please enter Invoice No")]
        [StringLength(10, MinimumLength = 5)]
        public int InvoiceNo { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please enter Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please enter Code")]
        [StringLength(5, MinimumLength = 3)]
        public string Code { get; set; }

        [Display(Name = "Manufactured Date")]
        [Required(ErrorMessage = "Please enter Manufactured Date")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedDate { get; set; }

        [Display(Name = "Expire Date")]
        [Required(ErrorMessage = "Please enter Expire Date")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please enter Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Unit Price(Tk)")]
        [Required(ErrorMessage = "Please enter Unit Price")]
        public double UnitPrice { get; set; }

        [Display(Name = "Total Price(Tk)")]
        [Required]
        public double TotalPrice { get; set; }

        [Display(Name = "Previous Cost Price(Tk)")]
        public double PreviousCostPrice { get; set; }

        [Display(Name = "Previous MRP(Tk)")]
        public double PreviousMRP { get; set; }

        [Display(Name = "New MRP(Tk)")]
        [Required(ErrorMessage = "Please enter New MRP")]
        public double MRP { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public IEnumerable<SelectListItem> SupplierSelectListItems { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductSelectListItems { get; set; }

        public int PurchaseSupplierId { get; set; }

        public List<PurchaseSupplier> PurchaseSupplier { get; set; }
        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}