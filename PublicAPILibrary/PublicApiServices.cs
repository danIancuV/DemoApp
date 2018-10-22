using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PublicAPILibrary
{
    public class PublicApiServices
    {
        public Rates GetCurrencyRates(string key)
        {
            string apiUrl = "http://data.fixer.io/api/latest?access_key=";
            var sb = new StringBuilder(apiUrl);
            using (var client = new HttpClient())
            {
                string repUrl = sb.Append(key).ToString();
                var response = client.GetAsync(repUrl).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = response.Content.ReadAsStringAsync().Result;
                var rootResult = JsonConvert.DeserializeObject<RootObject>(result);
                var currencyRates = rootResult.Rates;
                return currencyRates;
            }
        }

        public decimal GetSelectedCurrencyRate(string selectedcurrency)
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates currencyRates = GetCurrencyRates(key);
            decimal cadRateResult = Convert.ToDecimal(currencyRates.CAD);
            decimal eurRateResult = Convert.ToDecimal(currencyRates.EUR);
            decimal usdRateResult = Convert.ToDecimal(currencyRates.USD);
            switch (selectedcurrency)
            {
                case "CAD": return cadRateResult;
                case "EUR": return eurRateResult;
                case "USD": return usdRateResult;
            }

            return -1;
        }

        public async Task<decimal> ConvertAmountAsync(string fromcurrency, decimal initialamount, string tocurrency, IProgress<int> progress)
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates rates = GetCurrencyRates(key);
            decimal selectedFromCurrencyRateValue =
                Convert.ToDecimal(typeof(Rates).GetProperty(fromcurrency)?.GetValue(rates));
            decimal selectedToCurrencyRateValue =
                Convert.ToDecimal(typeof(Rates).GetProperty(tocurrency)?.GetValue(rates));
            var finalAmount =
                Math.Round(((initialamount / selectedFromCurrencyRateValue) * selectedToCurrencyRateValue), 2);
            for (int i = 0; i < 120; i++)
            {
                await Task.Delay(40); //.ConfigureAwait(false); // ConfigureAwait(false) avoiding deadlock
                progress?.Report(i);
            }

            return finalAmount;
        }

        public List<string> GetRatesList(string key)
        {
            Rates rates = GetCurrencyRates(key);
            var properties = rates.GetType().GetProperties().ToList();
            var fields = new List<string>();
            foreach (var prop in properties)
            {
                fields.Add(prop.Name);
            }

            return fields;
        }
    }
}
