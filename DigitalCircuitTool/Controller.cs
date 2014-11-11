using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalCircuitTool
{
    class Controller
    {
        private Grid grid;
        private static Controller controller = null;

        Item[] toBeconnectedItems = new Item[2];

        // private constructor
        private Controller()
        {
            this.grid = Grid.getGrid();
        }

        // public static getter of the singleton instance
        public static Controller getController() 
        {
            if (controller == null) 
            {
                controller = new Controller();
            }

            return controller;
        }

        public void addItem(Item item)
        {
            grid.addItem(item);
        }

        public void SaveGrid()
        {
            MessageBox.Show(grid.SaveGridStatusToFile());
        }

        public void LoadGrid()
        {
            MessageBox.Show(grid.LoadGridStatusFromFile());
        }

        public Item createItem(string itemName, Point position)
        {
            Item item = null;

            if (itemName.Equals(Utils.AND))
            {
                item = new AND(position);
            }
            else if (itemName.Equals(Utils.OR))
            {
                item = new OR(position);
            }
            else if (itemName.Equals(Utils.XOR))
            {
                item = new XOR(position);
            }
            else if (itemName.Equals(Utils.NOT))
            {
                item = new NOT(position);
            }
            else if (itemName.Equals(Utils.SOURCE0))
            {
                item = new Source(position, false);
            }
            else if (itemName.Equals(Utils.SOURCE1))
            {
                item = new Source(position, true);
            }
            else if (itemName.Equals(Utils.SINK))
            {
                item = new Sink(position);
            }

            if (item != null)
            {
                grid.addItem(item);

                return item;
            }

            return null;
        }

        public bool prepareConnection(Item p)
        {
            if (toBeconnectedItems[0] == null || toBeconnectedItems[1] == null)
            {
                if (toBeconnectedItems[0] == null)
                {
                    toBeconnectedItems[0] = p;
                }
                else
                {
                    toBeconnectedItems[1] = p;
                }

                return true;
            }

            return false;
        }

        public void connectTwoItems(Graphics gr)
        {
            if (grid.ConnectTwoItems(gr, toBeconnectedItems))
            {
                toBeconnectedItems[0].BorderStyle = BorderStyle.FixedSingle;
                toBeconnectedItems[1].BorderStyle = BorderStyle.FixedSingle;

                toBeconnectedItems[0].AddNeighborToItem(toBeconnectedItems[1]);
                ((GateOrSink)toBeconnectedItems[1]).changeOutput(toBeconnectedItems[0]);

                toBeconnectedItems = new Item[2];
            }
        }

        public void removeConnection(Graphics gr)
        {
            if (grid.removeConnection(gr, toBeconnectedItems[0], toBeconnectedItems[1]))
            {
                toBeconnectedItems[0].BorderStyle = BorderStyle.FixedSingle;
                toBeconnectedItems[1].BorderStyle = BorderStyle.FixedSingle;
                toBeconnectedItems = new Item[2];
            }
        }

        public void clearGrid()
        { 
            grid.ItemsList = new List<Item>();
        }

        public void unselectItem(PictureBox p)
        {
            if (toBeconnectedItems[0].Equals(p))
            {
                toBeconnectedItems[0] = toBeconnectedItems[1];
                toBeconnectedItems[1] = null;
            }
            else
                toBeconnectedItems[1] = null;

            p.BorderStyle = BorderStyle.FixedSingle;
        }

        public PictureBox deleteSelectedItem()
        {
            PictureBox pictureBox = null;
            if (toBeconnectedItems[0] != null)
            {
                grid.ItemsList.Remove(toBeconnectedItems[0]);
                pictureBox = (PictureBox)toBeconnectedItems[0];
                deleteItem(toBeconnectedItems[0]);
                toBeconnectedItems[0] = null;
            }
            else if (toBeconnectedItems[1] != null)
            {
                grid.ItemsList.Remove(toBeconnectedItems[1]);
                pictureBox = (PictureBox)toBeconnectedItems[1];
                deleteItem(toBeconnectedItems[1]);
                toBeconnectedItems[1] = null;
            }

            return pictureBox;
        }

        private void deleteItem(Item deleteItem)
        {
            foreach (Item item in grid.ItemsList)
            {
                foreach (Line line in deleteItem.InLines)
                {
                    item.OutLines.Remove(line);
                }
                foreach (Line line in deleteItem.OutLines)
                {
                    item.InLines.Remove(line);
                }
                item.deleteItem(deleteItem);
                item.ListOfNeighbors.Remove(deleteItem);
                item.calculate();
            }
            grid.ItemsList.Remove(deleteItem);
        }

        public void drawLines(Graphics gr)
        {
            grid.drawLines(gr);
        }
    }
}