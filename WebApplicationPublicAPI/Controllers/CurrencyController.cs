using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicAPILibrary;

namespace WebApplicationPublicAPI.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly PublicApiServices _publicApiServices = new PublicApiServices();

        
        // GET: Currency
        public ActionResult Index()
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates currencyRates = _publicApiServices.GetCurrencyRates(key);
            
            return View(currencyRates);
        }

        // GET: ConvertAsync
        public ActionResult ConvertAsync()
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            var currencyList = _publicApiServices.GetRatesList(key);
            ViewBag.listofcurrencies = currencyList;
            return View();
        }

        // POST: ConvertAsync
        [HttpPost]
        public async Task<ActionResult> ConvertAsync(string fromCurrency, string toCurrency, string initialAmount)
        {
            var watch = new Stopwatch();
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            var currencyList = _publicApiServices.GetRatesList(key);
            ViewBag.listofcurrencies = currencyList;

            try
            {
                watch.Start(); 
                var decimalInitialAmount = Decimal.Parse(initialAmount);          
                decimal finalAmount = await _publicApiServices.ConvertAmountAsync(fromCurrency, toCurrency, decimalInitialAmount);
                ViewBag.finalAmount = finalAmount;              
                ViewBag.elapsedTime = watch.ElapsedMilliseconds;
                watch.Stop();
                return View();
            }
            catch (ArgumentNullException)
            {
                ViewBag.error = "Please select a currency !!!";
                return View();

            }
        }

        // GET: Selected currency
        public ActionResult SelectedCurrencyRate()
        {
            var currencyList = new List<string> {"EUR", "USD", "CAD"};
            ViewBag.listofcurrencies = currencyList;
            return View();
        }

        // POST: Selected currency
        [HttpPost]
        public ActionResult SelectedCurrencyRate(string selectedCurrency)
        {
            var currencyList = new List<string> { "EUR", "USD", "CAD" };
            ViewBag.listofcurrencies = currencyList;

            decimal selectedCurrencyRate = _publicApiServices.GetSelectedCurrencyRate(selectedCurrency);

            if (selectedCurrencyRate == -1)
            {
                ViewBag.error = "Please select a currency !!!"; 
                return View();
            }

            ViewBag.selectedRate = selectedCurrencyRate;
            return View();
        }

        // GET: InstantUsdRate
        public ActionResult InstantUsdRate()
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            var instantUsdRate = _publicApiServices.GetCurrencyRates(key).USD.ToString(CultureInfo.InvariantCulture);
            

            ViewBag.Rate = instantUsdRate;
            return View();
        }
    }
}
