using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    class NOT : Gate
    {
        public NOT(Point positionn) : base(positionn) {}

        public override void changeOutput(Item input)
        {
            Input1 = input;
            calculate();

            setPenColor();
        }

        public override void calculate()
        {
            if (Input1 != null)
                Output = !Input1.Output;
            letThemKnow();
        }

        public override void deleteParent(Item parent)
        {
            if (Input1 != null && Input1.Equals(parent))
            {
                Input1 = null;
                calculate();
            }
        }

        public override void deleteItem(Item item)
        {
            if (Input1 != null && Input1.Equals(item))
                Input1 = null;
        }
    }
}
