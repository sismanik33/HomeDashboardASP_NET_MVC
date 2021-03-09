using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashboardWebUI.Models
{
    public class PurchaseDiplayModel
    {
        [Required]
        [Display(Name = "Date of Purchase")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        [Display(Name = "Purchase Description")]
        public string Description { get; set; }
        public bool Paid { get; set; }
        [Required]
        [Display(Name = "Who to Reimburse")]
        public string PartyToReimburse { get; set; }
        [Required]
        [Display(Name = "Purchase Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Entry must be numeric with up to 2 decimal places.")]
        public double PurchaseTotal { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Must be an integer between 1 and 10")]
        [Display(Name = "Draw")]
        public int DrawNumber { get; set; }
        [Url]
        [Display(Name = "Link")]
        public string ReceiptLink { get; set; }

    }
}