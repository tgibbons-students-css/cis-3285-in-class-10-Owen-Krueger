using CurrencyTrader;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        UrlTradeDataProvider urlTradeDataProvider;

        /// <summary>
        /// Create UrlTradeDataProvider
        /// </summary>
        /// <param name="url">url of trade data</param>
        public AdjustTradeDataProvider(String url)
        {
            urlTradeDataProvider = new UrlTradeDataProvider(url);
        }

        /// <summary>
        /// Get Trade data from UrlTradeDataProvider, but replace GBP with EUR
        /// </summary>
        /// <returns>List of strings of trade data</String></returns>
        public IEnumerable<string> GetTradeData()
        {
            List<String> tradeData = new List<String>();

            tradeData = urlTradeDataProvider.GetTradeData().ToList();

            for (int i = 0; i < tradeData.Count; i++)
            {
                if (tradeData[i].Contains("GBP"))
                {
                    tradeData[i] = tradeData[i].Replace("GBP", "EUR");
                }
            }

            return tradeData;
        }
    }
}
