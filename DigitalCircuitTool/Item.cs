using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalCircuitTool
{
    abstract class Item : PictureBox
    {
        private Point position;
        public Point Position { get { return position; } set { position = value; } }
        public static int Radius = 400; //the radius of every Item (that is why it is static)
        private List<Item> listOfNeighbors; // list of items to which the item is connected
        private long sequenceNumber; //sequence number of the item used to save connection between items

        private Pen pen = new Pen(Color.Black);
        public Pen Pen { get { return this.pen; } set { this.pen = value; } }

        private bool? output;
        public bool? Output { get { return this.output; } set { this.output = value; } }

        private List<Line> inLines;
        public List<Line> InLines { get { return inLines; } }
        
        private List<Line> outLines;
        public List<Line> OutLines { get { return outLines; } }

        internal List<Item> ListOfNeighbors{ get { return listOfNeighbors; } set { listOfNeighbors = value;}}
        public long SequenceNumber { get { return sequenceNumber; } set { sequenceNumber = value; } }
        
        public Item(Point positionn)
        {
            position = positionn;

            this.listOfNeighbors = new List<Item>();
            this.inLines = new List<Line>();
            this.outLines = new List<Line>();

            setPenColor();
        }

        //Adds item to its list of Neighbors
        public void AddNeighborToItem(Item i)
        {
            this.listOfNeighbors.Add(i);
        }

        //Removes item from its list of Neighbors
        public void RemoveNeighborFromItem(Item i)
        {
            this.listOfNeighbors.Remove(i);
        }

        //Checks if we are on specific "point"
        public bool ContainsPoint(Point point)
        {
            return (this.position.X - point.X) * (this.position.X - point.X) + (this.position.Y - point.Y) * (this.position.Y - point.Y) <= Radius * Radius;
        }


        //this method returns the list of sequance numbers of all neighbours
        public List<long> ReturnSeqNumbersOfNeighbours()
        {
            List<long> neighbours = new List<long>();
            if (listOfNeighbors.Count() != 0)
            {
                foreach (Item n in listOfNeighbors)
                {
                    neighbours.Add(n.SequenceNumber);
                }
            }
            return neighbours;
        }

        public abstract void calculate();
        public abstract void deleteItem(Item item);

        protected void setPenColor()
        {
            Pen.Color = Utils.getColor(Output);
        }
    }
}
