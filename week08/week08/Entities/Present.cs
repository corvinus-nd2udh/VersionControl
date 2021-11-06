﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entities
{
    class Present : Toy
    {
        public SolidBrush Box { get; private set; }
        public SolidBrush Ribbon { get; private set; }
        public Present(Color ribbon, Color box)
        {
            var ribbonBrush = new SolidBrush(ribbon);
            var boxBrush = new SolidBrush(box);
            Ribbon = ribbonBrush;
            Box = boxBrush;
        }
        protected override void DrawImage(Graphics graphics)
        {
            graphics.FillRectangle(Box, 0, 0, Width, Height);
            graphics.FillRectangle(Ribbon, 2 * Height / 5, 0, Width / 5, Height);
            graphics.FillRectangle(Ribbon, 0, 2 * Width / 5, Width, Height / 5);
        }
    }
}
