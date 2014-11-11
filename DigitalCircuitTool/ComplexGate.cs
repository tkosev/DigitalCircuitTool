using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    abstract class ComplexGate : Gate
    {
        private Item input2;
        public Item Input2 { get { return input2; } set { input2 = value; } }

        public ComplexGate(Point position) : base(position) {}

        public override void changeOutput(Item input)
        {
            bool? tempOutput = Output;

            if (Input1 == null && Input2 == null)
                Input1 = input;
            else if (Input1 == null && !Input2.Equals(input))
                Input1 = input;
            else if (Input2 == null && !Input1.Equals(input))
                Input2 = input;

            calculate();

            setPenColor();
            
            if (tempOutput != Output)
                letThemKnow();
        }

        public override void deleteParent(Item parent)
        {
            if (Input1 != null && Input1.Equals(parent))
            {
                Input1 = null;
                calculate();
            }
            else if (Input2 != null && Input2.Equals(parent))
            {
                Input1 = null;
                calculate();
            }
        }

        public override void deleteItem(Item item)
        {
            if (Input1 != null && Input1.Equals(item))
                Input1 = null;

            if (Input2 != null && Input2.Equals(item))
                Input2 = null;
        }
    }
}
