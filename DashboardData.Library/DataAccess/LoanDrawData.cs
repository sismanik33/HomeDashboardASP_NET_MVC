﻿using DashboardData.Library.Internal.DataAccess;
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
        public void SavePurcase(LoanDrawPurchaseDataModel purchaseToInsert)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveDataStoredProc("dbo.spPurchase_Insert", purchaseToInsert, "DashboardDB");
        }

        public List<LoanDrawPurchaseDataModel> LoadPurchases()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadDataStoredProc<LoanDrawPurchaseDataModel, dynamic>("dbo.spPurchases_GetAll", new { }, "DashboardDB");

            return output;
        }
    }
}
