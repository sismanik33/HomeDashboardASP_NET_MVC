﻿using DashboardData.Library.Models.StockDetailModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DashboardData.Library.BusinessLogic
{
    public static class StockDetailProcessor
    {
        public static async Task<List<StockModel>> GetStockDetails(List<string> symbolStringList)
        {
            var client = new HttpClient();
            StringBuilder sb = new StringBuilder();
            string baseUri = @"https://yahoo-finance-low-latency.p.rapidapi.com/v6/finance/quote?symbols=";
            string symbolsUri = String.Join("%2C", symbolStringList);
            
            sb.Append(baseUri);
            sb.Append(symbolsUri);
            //sb.Append("\"");

            string uri = sb.ToString();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "x-rapidapi-key", "cfea63c735msh4bd46d527fde8f5p1ede6fjsna7fba887a943" },
                    { "x-rapidapi-host", "yahoo-finance-low-latency.p.rapidapi.com" },
                },
            };

            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                QuoteResponse stocks = new QuoteResponse();
                if (response.IsSuccessStatusCode)
                {
                    StockApiResponse result = await response.Content.ReadAsAsync<StockApiResponse>();
                    stocks = result.QuoteResponse;
                }
                else
                {
                    Debug.WriteLine(response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }

                return stocks.Result;
            }

        }

    }
}
