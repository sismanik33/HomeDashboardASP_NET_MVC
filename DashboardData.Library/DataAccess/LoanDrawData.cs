using DashboardData.Library.Internal.DataAccess;
using DashboardData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.DataAccess
{
    public class LoanDrawData
    {
        public async Task SavePurchase(LoanDrawPurchaseDataModel purchaseToInsert)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveDataStoredProc("dbo.spPurchase_Insert", purchaseToInsert, "DashboardDB");
        }



        public async Task<List<LoanDrawPurchaseDataModel>> LoadPurchases()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = await sql.LoadDataStoredProc<LoanDrawPurchaseDataModel, dynamic>("dbo.spPurchases_GetAll", new { }, "DashboardDB");

            return output;
        }

        internal async Task UpdatePurchase(LoanDrawPurchaseDataModel purchaseToUpdate)
        {
            SqlDataAccess sql = new SqlDataAccess();

            await sql.SaveDataStoredProc("dbo.spPurchase_Update", purchaseToUpdate, "DashboardDB");
            
        }

        internal async Task deletePurchase(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            await sql.SaveDataStoredProc("dbo.spPurchase_DeleteById", new { Id = id }, "DashboardDB");
        }
    }
}
