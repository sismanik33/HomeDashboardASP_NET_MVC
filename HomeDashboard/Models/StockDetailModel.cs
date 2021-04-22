using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashboardWebUI.Models
{
    public class StockDetailModel
    {
        public string Symbol { get; set; }
        [Display(Name = "Name")]
        public string DisplayName { get; set; }
        [Display(Name = "Current Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double RegularMarketPrice { get; set; }
        [Display(Name = "50 Day Avg")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double FiftyDayAverage { get; set; }
        [Display(Name = "200 Day Avg")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TwoHundredDayAverage { get; set; }
        [Display(Name = "Market Cap")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public ulong MarketCap { get; set; }
        [Display(Name = "Exchange")]
        public string FullExchangeName { get; set; }
        [Display(Name = "52 Wk Lo")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double FiftyTwoWeekLow { get; set; }
        [Display(Name = "52 Wk Hi")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double FiftyTwoWeekHigh { get; set; }

    }
}