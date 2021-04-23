using DashboardData.Library.DataAccess;
using DashboardData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.BusinessLogic
{
    public static class StockSymbolProcessor
    {
        public static void SaveStockSymbol(string symbol)
        {
            StockSymbolData data = new StockSymbolData();
            StockSymbolDataModel stockToSave = new StockSymbolDataModel
            {
                StockSymbol = symbol
            };
            data.SaveStockSymbol(stockToSave);
        }

        public static List<StockSymbolDataModel> LoadSymbols()
        {
            StockSymbolData data = new StockSymbolData();
            var output = data.LoadStockSymbols();

            return output;
        }

        public static void RemoveStockFromList(string symbol)
        {
            StockSymbolData data = new StockSymbolData();
            data.DeleteStockSymbol(symbol);
        }
    }
}
