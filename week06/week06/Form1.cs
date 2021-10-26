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
        public Form1()
        {
            InitializeComponent();
            //WebService();
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
            //chartArea.AxisX.LineWidth = 2;
            //chartArea.AxisY.LineWidth = 2;
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
                rateData.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                //var value = decimal.Parse(childElement.InnerText);
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
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
        }
    }
}
