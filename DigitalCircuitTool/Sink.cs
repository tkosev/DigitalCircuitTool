using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    class Sink : GateOrSink
    {
        public Sink(Point position) : base(position) {}

        public override void changeOutput(Item input)
        {
            Input1 = input;
            switchOnOff();
        }

        public override void deleteParent(Item parent)
        {
            if (Input1 != null && Input1.Equals(parent))
            {
                Input1 = null;
                calculate();
            }
        }

        private void switchOnOff()
        {
            if (Input1.Output == null)
            {
                Image = Properties.Resources.lamp;
            }
            else if (Input1.Output == true)
            {
                Image = Properties.Resources.onbulb;
            }
            else
            {
                Image = Properties.Resources._null;
            }
        }

        public override void calculate() 
        {
            switchOnOff();
        }

        public override void deleteItem(Item item) 
        {
            if (Input1 != null && Input1.Equals(item))
                Input1 = null;
        }
    }
}