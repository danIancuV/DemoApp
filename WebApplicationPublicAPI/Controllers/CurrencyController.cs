using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicAPILibrary;
using WebApplicationPublicAPI.Models;

namespace WebApplicationPublicAPI.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly PublicApiServices _publicApiServices = new PublicApiServices();

        
        // GET: Currency
        public ActionResult Index()
        {
            //think about making a new method hat can be used by ajax call and index call for 
            //populating table with first batch then next batches with ajax call

            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates currencyRates = _publicApiServices.GetCurrencyRates(key);
            List<RateDto> ratesList = RateDto.MapToRateDtoList(currencyRates).GetRange(0,10);

            return View(ratesList);          
        }

        // GET: Currency JSON format
        public ActionResult GetJsonRates(int page)
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates currencyRates = _publicApiServices.GetCurrencyRates(key);
            List<RateDto> ratesList = RateDto.MapToRateDtoList(currencyRates);

            int rangeStart = 0;
            int rangeLength = 0;

            int pageSize = 10;
            int pageNumber = page;

            if ((pageNumber * pageSize) > ratesList.Count)
                return new EmptyResult();

            if (((pageNumber * pageSize) + pageSize) > ratesList.Count)
            {
                rangeLength = ratesList.Count % pageSize;
                rangeStart = ratesList.Count - rangeLength;
            }
            else
            {
                rangeStart = (pageNumber * pageSize);
                rangeLength = pageSize;
            }

            ratesList = ratesList.GetRange(rangeStart, rangeLength);

            ViewBag.Page = pageNumber + 1;
            return Json(ratesList);
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
