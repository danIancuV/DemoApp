using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PublicAPIDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            var currencyResult = GetCurrency();
            dataGridView1.DataSource = currencyResult;
        }

        public static List<Rates> GetCurrency()
        {
            const string apiUrl = "http://data.fixer.io/api/latest?access_key=";
            const string apiKey = "c6469effe16603f8a5b21335e6b9b027";

            using (var client = new HttpClient())
            {
                const string repUrl = apiUrl + apiKey + "&symbols=CAD,EUR,USD&format=1";
                var response = client.GetAsync(repUrl).Result;

                if (!response.IsSuccessStatusCode) return null;
                var result = response.Content.ReadAsStringAsync().Result;
                var rootResult = JsonConvert.DeserializeObject<RootObject>(result);
                var ratesList = new List<Rates> { rootResult.rates };
                return ratesList;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currencyResultList = GetCurrency();
            var selectedCadCurrencyResult = currencyResultList[0].CAD;
            var selectedEurCurrencyResult = currencyResultList[0].EUR;
            var selectedUsdCurrencyResult = currencyResultList[0].USD;

            var currency = comboBox1.SelectedItem.ToString();
            switch (currency)
            {
                case "CAD":
                    label1.Text = selectedCadCurrencyResult.ToString();
                    break;
                case "EUR":
                    label1.Text = selectedEurCurrencyResult.ToString();
                    break;
                case "USD":
                    label1.Text = selectedUsdCurrencyResult.ToString();
                    break;
            }
        }


    }
}
