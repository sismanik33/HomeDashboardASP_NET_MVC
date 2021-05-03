using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DashboardWebUI.Models;
using DashboardData.Library.BusinessLogic;
using DashboardData.Library.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using DashboardData.Library.Models.StockDetailModels;

namespace DashboardWebUI.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        public ActionResult Index()
        {
            return RedirectToAction("WatchList");
        }

        public async Task<ActionResult> WatchList()
        {
            ViewBag.Message = "Stocks in Watch List";

            var data = await StockSymbolProcessor.LoadSymbols();
            List<StockSymbolModel> stocks = new List<StockSymbolModel>();

            foreach (var symbol in data)
            {
                stocks.Add(new StockSymbolModel
                {
                    Symbol = symbol
                });
            }

            return View(stocks);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Message = "Add Stock To Watch List";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Models.StockSymbolModel stock)
        {
            if (ModelState.IsValid)
            {
                await StockSymbolProcessor.SaveStockSymbol(stock.Symbol.Trim().ToUpper());
                return RedirectToAction("WatchList");
            }

            return View();
        }

        public async Task<ActionResult> ListDetails()
        {
            ViewBag.Message = "Stock Watch List Details";

            var stockSymbols = await StockSymbolProcessor.LoadSymbols();

            //Return a list of StockModel from DashboardData.Library.Models
            var stockDetailList = new List<StockModel>();
            try
            {
                stockDetailList = await StockDetailProcessor.GetStockDetails(stockSymbols);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            

            //Map returned list to StockDetailModel
            List<StockDetailModel> stockDetailResults = new List<StockDetailModel>();
            foreach (var stock in stockDetailList)
            {
                stockDetailResults.Add(new StockDetailModel
                {
                    Symbol = stock.Symbol,
                    DisplayName = stock.DisplayName,
                    RegularMarketPrice = stock.RegularMarketPrice,
                    FiftyDayAverage = stock.FiftyDayAverage,
                    TwoHundredDayAverage = stock.TwoHundredDayAverage,
                    MarketCap = stock.MarketCap,
                    FullExchangeName = stock.FullExchangeName,
                    FiftyTwoWeekLow = stock.FiftyTwoWeekLow,
                    FiftyTwoWeekHigh = stock.FiftyTwoWeekHigh
                });
            }

            //Sort list by market cap (descending)
            stockDetailResults.Sort((s1, s2) => s2.MarketCap.CompareTo(s1.MarketCap));

            return View(stockDetailResults);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string symbol = "test", bool saveChangesError = false)
        {
            ViewBag.Message = "Remove Stock From Watch List";

            var stockSymbols = await StockSymbolProcessor.LoadSymbols();
            bool stockExists = stockSymbols.Exists(x => x == symbol.Trim().ToUpper());

            if (stockExists == false)
            {
                return RedirectToAction("WatchList");
            }
            if (saveChangesError)
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            var stock = stockSymbols.Find(x => x == symbol.Trim().ToUpper());
            StockSymbolModel stockToDelete = new StockSymbolModel
            {
                Symbol = stock
            };

            return View(stockToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(StockSymbolModel stock)
        {
            if (ModelState.IsValid)
            {
                await StockSymbolProcessor.RemoveStockFromList(stock.Symbol);
                return RedirectToAction("WatchList");
            }

            return View();
        }

    }
}
