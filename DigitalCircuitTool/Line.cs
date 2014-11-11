using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    class Line
    {
        public Line(Point from, Point to)
        {
            this.from = from;
            this.to = to;
        }

        private Point from;
        public Point From { get { return this.from; } set { this.from = value; } }

        private Point to;
        public Point To { get { return this.to; } set { this.to = value; } }
    }
}
