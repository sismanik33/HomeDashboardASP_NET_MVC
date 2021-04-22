using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashboardWebUI.Models
{
    public class StockSymbolModel
    {
        [Required]
        public string Symbol { get; set; }
    }
}