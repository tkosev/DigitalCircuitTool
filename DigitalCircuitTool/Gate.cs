using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigitalCircuitTool
{
    abstract class Gate : GateOrSink
    {
        public Gate(Point position) : base(position)
        {
        }

        public bool AddItem(GateOrSink item)
        {
            return true;
        }

        public GateOrSink FindGateOrSink(string chipNumber)
        {
            return null;
        }

        public void letThemKnow()
        {
            foreach (GateOrSink item in ListOfNeighbors)
            {
                item.changeOutput(this);
            }

            setPenColor();
        }
    }
}