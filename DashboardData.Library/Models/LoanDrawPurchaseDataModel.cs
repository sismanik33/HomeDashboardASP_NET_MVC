using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.Models
{
    public class LoanDrawPurchaseDataModel
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Vendor { get; set; }
        public string Description { get; set; }
        public bool Paid { get; set; }
        public string PartyToReimburse { get; set; }
        public double PurchaseTotal { get; set; }
        public int DrawNumber { get; set; }
        public string ReceiptLink { get; set; }
        public bool PartialPayment { get; set; }
    }
}
