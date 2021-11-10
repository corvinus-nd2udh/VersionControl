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
        Toy _nextToy;

        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null) Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Left = label1.Left + label1.Width + 20;
            _nextToy.Top = label1.Top;
            Controls.Add(_nextToy);
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

        private void buttonCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void buttonBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory() { BallColor = buttonColor.BackColor };
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorDialog = new ColorDialog();
            colorDialog.Color = button.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            button.BackColor = colorDialog.Color;
        }

        private void buttonPresent_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                BoxColor = buttonBoxColor.BackColor,
                RibbonColor = buttonRibbonColor.BackColor
            };
        }
    }
}
