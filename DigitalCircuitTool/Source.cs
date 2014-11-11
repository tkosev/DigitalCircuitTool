using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalCircuitTool
{
    class Source : Item
    {
        //Constructor of Source with position and outputt set to false
        public Source(Point position, bool output) : base(position)
        {
            Output = output;
            setPenColor();
        }

        //Changes the value from false to true and vise-versa.
        public bool? changeSourceValue()
        {
            Output = !Output;
            setPenColor();

            letThemKnow();

            return Output;
        }

        private void letThemKnow()
        {
            foreach (GateOrSink item in ListOfNeighbors)
            {
                item.changeOutput(this);
            }
        }

        public override void calculate() {}

        public override void deleteItem(Item item) {}
    }
}