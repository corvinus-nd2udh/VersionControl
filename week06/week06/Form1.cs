using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.MnbServiceReference;
using week06.Entities;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace week06
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            //Currencies lekérdezés
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrenciesRequestBody();
            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;
            //Console.WriteLine(result);
            CurrenciesXML(result);
            comboBoxCurrency.DataSource = Currencies;
            RefreshData();
        }

        private void CurrenciesXML(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement.ChildNodes[0])
            {
                string data = element.InnerText;
                Currencies.Add(data);
            }
        }

        private void RefreshData()
        {
            Rates.Clear();
            dataGridView1.DataSource = Rates;
            ProcessXML(WebService());
            DeployChart();
        }

        private void DeployChart()
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

        }

        private void ProcessXML(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                RateData rateData = new RateData();
                Rates.Add(rateData);

                rateData.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null) continue;
                rateData.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText, CultureInfo.GetCultureInfo("hu-HU"));
                if (unit != 0)
                {
                    rateData.Value = value / unit;
                }
                else rateData.Value = unit;
            }
        }

        private string WebService()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody
            {
                currencyNames = (string)comboBoxCurrency.SelectedItem,
                startDate = dateTimePickerStart.Value.ToString(),
                endDate = dateTimePickerEnd.Value.ToString()
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
