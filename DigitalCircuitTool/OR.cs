using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    class OR : ComplexGate
    {
        public OR(Point position) : base(position) {}

        public override void calculate()
        {
            if (Input1 != null && Input2 != null)
                this.Output = Input1.Output | Input2.Output;
            else
                this.Output = null;

            letThemKnow();
        }
    }
}