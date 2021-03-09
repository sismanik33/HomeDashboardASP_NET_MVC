using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.Models.StockDetailModels
{
    public class StockModel
    {
        public string Symbol { get; set; }
        public string DisplayName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double FiftyDayAverage { get; set; }
        public double TwoHundredDayAverage { get; set; }
        public ulong MarketCap { get; set; }
        public string FullExchangeName { get; set; }
        public double FiftyTwoWeekLow { get; set; }
        public double FiftyTwoWeekHigh { get; set; }

    }

}
