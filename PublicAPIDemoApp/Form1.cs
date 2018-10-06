using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            GetRatesList();
            comboBox2.DataSource = GetRatesList();
            comboBox3.DataSource = GetRatesList();
            textBox2.ReadOnly = true;
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            var currencyResult = GetCurrency();
            dataGridView1.DataSource = currencyResult;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedCurrency();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConvertedFinalAmount();
        }

        private static List<Rates> GetCurrency()
        {
            const string apiUrl = "http://data.fixer.io/api/latest?access_key=";
            const string apiKey = "c6469effe16603f8a5b21335e6b9b027";

            using (var client = new HttpClient())
            {
                const string repUrl = apiUrl + apiKey + "&format=1";
                var response = client.GetAsync(repUrl).Result;

                if (!response.IsSuccessStatusCode) return null;
                var result = response.Content.ReadAsStringAsync().Result;
                var rootResult = JsonConvert.DeserializeObject<RootObject>(result);
                var ratesList = new List<Rates> { rootResult.rates };
                return ratesList;               
            }
        }
 
        private void GetSelectedCurrency()
        {
            var currencyResultList = GetCurrency();
            var selectedCadCurrencyResult = currencyResultList[0].CAD;
            var selectedEurCurrencyResult = currencyResultList[0].EUR;
            var selectedUsdCurrencyResult = currencyResultList[0].USD;

            var currency = comboBox1.SelectedItem.ToString();
            switch (currency)
            {
                case "CAD":
                    label1.Text = selectedCadCurrencyResult.ToString(CultureInfo.CurrentCulture);
                    break;
                case "EUR":
                    label1.Text = selectedEurCurrencyResult.ToString(CultureInfo.CurrentCulture);
                    break;
                case "USD":
                    label1.Text = selectedUsdCurrencyResult.ToString(CultureInfo.CurrentCulture);
                    break;
            }
        } 

        private void GetConvertedFinalAmount()
        {
            var rates = GetCurrency()[0];
            var fromCurrencyName = comboBox2.SelectedItem.ToString();
            var toCurrencyName = comboBox3.SelectedItem.ToString();
            var selectedFromCurrencyRateValue =
                Convert.ToDouble(typeof(Rates).GetProperty(fromCurrencyName)?.GetValue(rates));
            var selectedToCurrencyRateValue =
                Convert.ToDouble(typeof(Rates).GetProperty(toCurrencyName)?.GetValue(rates));           
            try
            {
                var initialAmount = Double.Parse(textBox1.Text);
                var finalAmount = Math.Round(((initialAmount / selectedFromCurrencyRateValue) * selectedToCurrencyRateValue), 2);
                
                textBox2.Text = finalAmount.ToString(CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Please specify an amount!");
            }
        }

        private List<string> GetRatesList()
        {
            Rates rates = GetCurrency()[0];
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
