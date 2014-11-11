using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    class AND : ComplexGate
    {

        public AND(Point positionn) : base(positionn) {}

        public override void calculate()
        {
            if (Input1 != null && Input2 != null)
                this.Output = Input1.Output & Input2.Output;
            else
                this.Output = null;
        }
    }
}
