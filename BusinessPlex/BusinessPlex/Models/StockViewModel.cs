using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPlex.Models
{
    public class StockViewModel
    {
        [Display(Name = "Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Expired Date")]
        public DateTime ExpiredDate { get; set; }

        [Display(Name = "Expired Qty")]
        public int ExpiredQuantity { get; set; }

        [Display(Name = "Opening Balance")]
        public int OpeningBalance { get; set; }

        [Display(Name = "In")]
        public int StockIn { get; set; }

        [Display(Name = "Out")]
        public int StockOut { get; set; }

        [Display(Name = "Closing Balance")]
        public int ClosingBalance { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public List<Product> Products { get; set; }
    }
}