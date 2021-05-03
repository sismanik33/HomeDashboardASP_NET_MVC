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
        public async Task<List<StockSymbolDataModel>> LoadStockSymbols()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = await sql.LoadDataStoredProc<StockSymbolDataModel, dynamic>("dbo.spStockSymbol_GetAll", new { }, "DashboardDB");

            return output;
        }

        public async Task SaveStockSymbol(StockSymbolDataModel stockToInsert)
        {            
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveDataStoredProc("dbo.spStockSymbol_Insert", stockToInsert, "DashboardDB");
        }

        public async Task DeleteStockSymbol(string stockToDelete)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveDataStoredProc("dbo.spStockSymbol_Delete", new { StockSymbol = stockToDelete }, "DashboardDB");
        }
    }
}
