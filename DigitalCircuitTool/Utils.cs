using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace DigitalCircuitTool
{
    class Utils
    {
        public static string SOURCE0 = "pbSOURCE0";
        public static string SOURCE1 = "pbSOURCE1";
        public static string AND = "pbAND";
        public static string OR = "pbOR";
        public static string XOR = "pbXOR";
        public static string NOT = "pbNOT";
        public static string SINK ="pbSINK";

        public static Color getColor(bool? value)
        { 
            if (value == true)
                return Color.Red;
            else if (value == false)
                return Color.Black;
            else
                return Color.Green;
        }
    }
}
