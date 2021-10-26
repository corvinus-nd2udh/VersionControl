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
        }

        private void ProcessXML(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                var childElement = (XmlElement)element.ChildNodes[0];
                decimal value;
                if (childElement.InnerText.Equals('0'))
                {
                    value = decimal.Parse(childElement.GetAttribute("unit"));
                }
                else
                {
                    value = decimal.Parse(childElement.GetAttribute("unit")) / decimal.Parse(childElement.InnerText);
                }
                RateData rateData = new RateData()
                {
                    Date = DateTime.Parse(element.GetAttribute("date")),
                    Currency = childElement.GetAttribute("curr"),
                    Value = value
                };
                Rates.Add(rateData);
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
