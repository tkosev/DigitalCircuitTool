using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DigitalCircuitTool
{
    class SaverLoader
    {
        
        //fields
        private Grid grid;
        private string fileName;

        //constructor
        public SaverLoader(Grid grid, string fileName)
        {
            this.grid = grid;
            this.fileName = fileName;
        }

        public void SaveGridToFile()
        {
            StreamWriter sw = new StreamWriter(fileName);
            //define two string variables: one for a complete string and one for a type
            string str;
            string t;
            sw.WriteLine("Information about items");

            //write current sequence number 
            str = grid.currentSequenceNumber.ToString() + " ";
            sw.WriteLine(str);

            //now we want to save the states of items
            foreach (Item i in grid.ItemsList)
            {
                str = "";
                t = "";
                //write item's sequence number
                str = i.SequenceNumber.ToString() + " ";

                //write item's coordinates
                str += i.Position.X.ToString() + " " + i.Position.Y.ToString() + " ";

                //get a type of an item
                t = i.GetType().ToString();
                str += t + " ";

                //now depending on a type get input and output info                   
                if (t == "DigitalCircuitTool.Source")
                {
                    Source s;
                    s = (Source)i;
                    str += s.Output.ToString() + " ";
                }
                else if (t == "DigitalCircuitTool.Sink")
                {
                    Sink s;
                    s = (Sink)i;
                    str += s.Output.ToString() + " ";
                    if (s.Input1 != null)
                        str += s.Input1.SequenceNumber.ToString() + " ";
                    else
                        str += "0 ";
                }
                else if (t == "DigitalCircuitTool.NOT")
                {
                    NOT n;
                    n = (NOT)i;
                    str += n.Output.ToString() + " ";
                    if (n.Input1 != null)
                        str += n.Input1.SequenceNumber.ToString() + " ";
                    else
                        str += "0 ";
                }
                else if (t == "DigitalCircuitTool.AND" || t == "DigitalCircuitTool.OR" || t == "DigitalCircuitTool.XOR")
                {
                    ComplexGate cg;
                    cg = (ComplexGate)i;
                    if (cg.Output.ToString() != null)
                        str += cg.Output.ToString() + " ";
                    else
                        str += "0 ";
                    if (cg.Input1 != null)
                        str += cg.Input1.SequenceNumber.ToString() + " ";
                    else
                        str += "0 ";
                    if (cg.Input2 != null)
                        str += cg.Input2.SequenceNumber.ToString() + " ";
                    else
                        str += "0 ";
                }
                sw.WriteLine(str);
            }
            sw.Close();
        }

        //write information about neighbours to file
        public void SaveInfoAboutNeigbours()
        {
            StreamWriter sw = new StreamWriter(fileName);
            string str;

            sw.WriteLine("Information about neighbours");
            foreach (Item i in grid.ItemsList)
            {
                if (i.ListOfNeighbors != null)
                {
                    str = "";
                    str = i.SequenceNumber.ToString() + " ";
                    foreach (Item neighbour in i.ListOfNeighbors)
                    {
                        str += neighbour.SequenceNumber.ToString() + " ";
                    }
                    sw.WriteLine(str);
                }
            }
            sw.Close();
        }

        public void RestoreGridFromFile()
        {
            StreamReader sr = new StreamReader(fileName);
            string line;

            grid.ItemsList.Clear();

            line = sr.ReadLine();
            line = sr.ReadLine();
            grid.currentSequenceNumber = Convert.ToInt64(FetchNewValue(line));

            //for each line-item in a file
            while ((line = sr.ReadLine()) != null)
            {
                Point coordinates = new Point();
                long sn;
                bool output;
                Item input1, input2;
                string typeOfItem;

                sn = Convert.ToInt64(FetchNewValue(line));
                line = RemoveUsedValueFromLine(line);

                coordinates.X = Convert.ToInt32(FetchNewValue(line));
                line = RemoveUsedValueFromLine(line);

                coordinates.Y = Convert.ToInt32(FetchNewValue(line));
                line = RemoveUsedValueFromLine(line);

                typeOfItem = FetchNewValue(line);
                line = RemoveUsedValueFromLine(line);

                if (typeOfItem == "DigitalCircuitTool.Source")
                {
                    output = Convert.ToBoolean(FetchNewValue(line));
                    Source item = new Source(coordinates, output);
                    item.SequenceNumber = sn;
                    grid.ItemsList.Add(item);
                }
                else if (typeOfItem == "DigitalCircuitTool.Sink")
                {
                    output = Convert.ToBoolean(FetchNewValue(line));
                    input1 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    Sink item = new Sink(coordinates);
                    item.SequenceNumber = sn;
                    item.Output = output;
                    item.Input1 = input1;                    
                    grid.ItemsList.Add(item);
                }
                else if (typeOfItem == "DigitalCircuitTool.NOT")
                {
                    output = Convert.ToBoolean(FetchNewValue(line));
                    input1 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    NOT item = new NOT(coordinates);
                    item.SequenceNumber = sn;
                    item.Output = output;
                    item.Input1 = input1;
                    grid.ItemsList.Add(item);
                }
                else if (typeOfItem == "DigitalCircuitTool.AND")
                {
                    output = Convert.ToBoolean(FetchNewValue(line));
                    input1 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    input2 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    AND item = new AND(coordinates);
                    item.SequenceNumber = sn;
                    item.Output = output;
                    item.Input1 = input1;
                    item.Input2 = input2;
                    grid.ItemsList.Add(item);
                }
                else if (typeOfItem == "DigitalCircuitTool.OR")
                {

                    output = Convert.ToBoolean(FetchNewValue(line));
                    input1 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    input2 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    OR item = new OR(coordinates);
                    item.SequenceNumber = sn;
                    item.Output = output;
                    item.Input1 = input1;
                    item.Input2 = input2;
                    grid.ItemsList.Add(item);
                }
                else if (typeOfItem == "DigitalCircuitTool.XOR")
                {
                    output = Convert.ToBoolean(FetchNewValue(line));
                    input1 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    input2 = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                    XOR item = new XOR(coordinates);
                    item.SequenceNumber = sn;
                    item.Output = output;
                    item.Input1 = input1;
                    item.Input2 = input2;
                    grid.ItemsList.Add(item);
                }
            }
            sr.Close();
        }

        public void LoadInfoAboutNeighbours()
        {
            StreamReader sr = new StreamReader(fileName);
            string line, str;
            Item activeItem;

            sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
            {
                activeItem = grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(line)));
                line = RemoveUsedValueFromLine(line);
                while ((str = FetchNewValue(line)) != null)
                {
                    activeItem.ListOfNeighbors.Add(grid.GetItemBySequenceNumber(Convert.ToInt64(FetchNewValue(str))));
                    line = RemoveUsedValueFromLine(line);
                    line = RemoveUsedValueFromLine(line);
                }
            }
        }

        private string FetchNewValue(string line)
        {
            int position;
            position = line.IndexOf(' ');
            return line.Substring(0, position);
        }

        private string RemoveUsedValueFromLine(string line)
        {
            int position;
            position = line.IndexOf(' ');
            return line.Remove(0, position + 1);
        }
    }
}
