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
        public static async Task SavePurchase(LoanDrawPurchaseDataModel purchase)
        {
            var data = new LoanDrawData();
            await data.SavePurchase(purchase);
        }

        public static async Task<List<LoanDrawPurchaseDataModel>> GetPurchases()
        {
            var data = new LoanDrawData();
            List<LoanDrawPurchaseDataModel> output = await data.LoadPurchases();

            return output;
        }

        public static async Task UpdatePurchase(LoanDrawPurchaseDataModel purchaseToUpdate)
        {
            var data = new LoanDrawData();
            await data.UpdatePurchase(purchaseToUpdate);
        }

        public static async Task DeletePurchase(int id)
        {
            var data = new LoanDrawData();
            await data.deletePurchase(id);
        }
    }
}
