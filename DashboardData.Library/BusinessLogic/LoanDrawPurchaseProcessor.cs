using DashboardData.Library.DataAccess;
using DashboardData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.BusinessLogic
{
    public static class LoanDrawPurchaseProcessor
    {
        public static void SavePurchase(LoanDrawPurchaseDataModel purchase)
        {
            var data = new LoanDrawData();
            data.SavePurchase(purchase);
        }

        public static List<LoanDrawPurchaseDataModel> GetPurchases()
        {
            var data = new LoanDrawData();
            List<LoanDrawPurchaseDataModel> output = data.LoadPurchases();

            return output;
        }

        public static void UpdatePurchase(LoanDrawPurchaseDataModel purchaseToUpdate)
        {
            var data = new LoanDrawData();
            data.UpdatePurchase(purchaseToUpdate);
        }
    }
}
