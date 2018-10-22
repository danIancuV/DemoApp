using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
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
            
            
            CultureInfo invariantculture = CultureInfo.InvariantCulture; // culture indepent - invariant, en-US by default
            CultureInfo currentculture = CultureInfo.CurrentCulture; // used by the current thread
            CultureInfo currentUIculture = CultureInfo.CurrentUICulture; // used by UI
            CultureInfo installedUIculture = CultureInfo.InstalledUICulture; // installed with the OS
            CultureInfo defaultthreadcurrent = CultureInfo.DefaultThreadCurrentCulture; // default culture for threads
            CultureInfo defaultthreadcurrentUi = CultureInfo.DefaultThreadCurrentUICulture; // default UI culture for threads

            decimal value = 3.14M;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en");
            var formattedvalue = value.ToString(culture);
            currentculture = culture;
            defaultthreadcurrent = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            selectedRateLabel.Text = _services.GetSelectedCurrencyRate(currency).ToString(currentculture) + " " + currentculture;
        }

        private async void ConvertButtonClick(object sender, EventArgs e)
        {         
            var fromCurrency = fromCurrencyComboBox.SelectedItem.ToString();
            var toCurrency = toCurrencyComboBox.SelectedItem.ToString();
            try
            {               
                var initialAmount = Decimal.Parse(initialAmountTextBox.Text);
                var progressIndicator = new Progress<int>(ReportProgress);
                Task<decimal> finalAmount = _services.ConvertAmountAsync(fromCurrency, initialAmount, toCurrency, progressIndicator);
                //finalAmountTextBox.Text = finalAmount.Result.ToString(CultureInfo.CurrentCulture); //deadlock (no ConfigureAwait(false))
                
                decimal res = await finalAmount;
                finalAmountTextBox.Text = res.ToString(CultureInfo.CurrentUICulture); // deadlock-proof snippet
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

        void ReportProgress(int value)
        {
            convertProgressBar.Increment(1);
        }

    }
}
