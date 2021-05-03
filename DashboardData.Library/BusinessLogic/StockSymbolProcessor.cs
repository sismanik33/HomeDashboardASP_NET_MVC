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
        public static async Task SaveStockSymbol(string symbol)
        {
            StockSymbolData data = new StockSymbolData();
            StockSymbolDataModel stockToSave = new StockSymbolDataModel
            {
                StockSymbol = symbol
            };
            await data.SaveStockSymbol(stockToSave);
        }

        public static async Task<List<string>> LoadSymbols()
        {
            StockSymbolData data = new StockSymbolData();
            var symbols = await data.LoadStockSymbols();
            var output = TrimToUpperList(symbols);

            return output;
        }

        public static async Task RemoveStockFromList(string symbol)
        {
            StockSymbolData data = new StockSymbolData();
            await data.DeleteStockSymbol(symbol);
        }

        private static List<string> TrimToUpperList(List<StockSymbolDataModel> list)
        {
            List<string> stockSymbolList = new List<string>();

            foreach (var stock in list)
            {
                stockSymbolList.Add(stock.StockSymbol.Trim().ToUpper());
            }

            return stockSymbolList;
        }
    }
}
