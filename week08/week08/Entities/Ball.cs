using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;

namespace week08.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        public Ball(Color color)
        {
            var brush = new SolidBrush(color);
            BallColor = brush;
            Click += Ball_Click;
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            Invalidate();
            Random rnd = new Random();
            BallColor = new SolidBrush(Color.FromArgb(rnd.Next(1, 255), rnd.Next(1, 255), rnd.Next(1, 255)));
        }

        protected override void DrawImage(Graphics graphics)
        {
            graphics.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        protected override void ShowType()
        {
            MessageBox.Show("Ball");
        }
    }
}
