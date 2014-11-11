using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    abstract class GateOrSink : Item
    {
        private Item input1;
        public Item Input1 { get { return input1; } set { input1 = value; } }

        public GateOrSink(Point position) : base(position)
        {
        }

        public abstract void changeOutput(Item input);
        public abstract void deleteParent(Item item);
    }
}