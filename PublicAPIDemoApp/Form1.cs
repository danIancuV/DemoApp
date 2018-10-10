using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PublicAPILibrary;

namespace PublicAPIDemoApp
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _gridBindingSource = new BindingSource();
        private readonly PublicApiServices _services = new PublicApiServices();
        
       
        public Form1()
        {
            InitializeComponent();
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            fromCurrencyComboBox.DataSource = _services.GetRatesList(key);
            toCurrencyComboBox.DataSource = _services.GetRatesList(key);
            finalAmountTextBox.ReadOnly = true;          
        }
        private void GetRatesButton_Click(object sender, EventArgs e)
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            Rates currencyRates = _services.GetCurrencyRates(key);
            _gridBindingSource.Add(currencyRates);
            RatesGridView.DataSource = _gridBindingSource;
        }
      
        private void CurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            var currency = CurrencyComboBox.SelectedItem.ToString();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            selectedRateLabel.Text = _services.GetSelectedCurrencyRate(currency).ToString(CultureInfo.DefaultThreadCurrentCulture) + " " + CultureInfo.CurrentCulture;            
        }

        private void ConvertButtonClick(object sender, EventArgs e)
        {          
            var fromCurrency = fromCurrencyComboBox.SelectedItem.ToString();
            var toCurrency = toCurrencyComboBox.SelectedItem.ToString();           
            try
            {
                var initialAmount = Decimal.Parse(initialAmountTextBox.Text);
                decimal finalAmount = _services.ConvertAmount(fromCurrency, initialAmount, toCurrency);
                finalAmountTextBox.Text = finalAmount.ToString(CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Please specify an amount!");
                finalAmountTextBox.Clear();
            }
        }

        private void InstantUSDRateButton_Click(object sender, EventArgs e)
        {
            const string key = "c6469effe16603f8a5b21335e6b9b027";
            var instantUsdRate = _services.GetCurrencyRates(key).USD.ToString(CultureInfo.InvariantCulture);
            MessageBox.Show($@"USD rate is: {instantUsdRate}");
        }

    }
}
