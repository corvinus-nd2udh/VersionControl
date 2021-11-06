using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            toy.Left = -toy.Width;
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int rightmostPosition = 0;
            foreach (var item in _toys)
            {
                item.MoveToy();
                if (item.Left > rightmostPosition) rightmostPosition = item.Left;
            }
            if (rightmostPosition >= 1000)
            {
                var first = _toys[0];
                _toys.Remove(first);
                mainPanel.Controls.Remove(first);
            }
        }
    }
}
