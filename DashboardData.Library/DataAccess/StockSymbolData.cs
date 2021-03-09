using DashboardData.Library.Internal.DataAccess;
using DashboardData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.DataAccess
{
    public class StockSymbolData
    {
        public List<StockSymbolDataModel> LoadStockSymbols()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadDataStoredProc<StockSymbolDataModel, dynamic>("dbo.spStockSymbol_GetAll", new { }, "DashboardDB");

            return output;
        }

        public void SaveStockSymbol(StockSymbolDataModel stockToInsert)
        {            
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveDataStoredProc("dbo.spStockSymbol_Insert", stockToInsert, "DashboardDB");
        }

        public void DeleteStockSymbol(string stockToDelete)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveDataStoredProc("dbo.spStockSymbol_Delete", new { StockSymbol = stockToDelete }, "DashboardDB");
        }
    }
}
