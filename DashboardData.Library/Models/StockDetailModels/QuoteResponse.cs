using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.Models.StockDetailModels
{
    public class QuoteResponse
    {
        public List<StockModel> Result { get; set; }

    }
}
