using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DigitalCircuitTool
{
    class Grid
    {
        private List<Item> itemslist;
        public List<Item> ItemsList { get { return itemslist; } set { itemslist = value; } }

        private static Grid grid = null;
        public long currentSequenceNumber; //Contains current sequence number of items

        // private constructor
        private Grid()
        {
            this.itemslist = new List<Item>();

            this.currentSequenceNumber = 1;
        }

        // public static getter of the singleton instance
        public static Grid getGrid() 
        {
            if (grid == null) 
            {
                grid = new Grid();
                grid.currentSequenceNumber = 1;
            }

            return grid;
        }

        public void addItem(Item item) 
        {
            item.SequenceNumber = this.currentSequenceNumber;
            this.currentSequenceNumber++;
            this.itemslist.Add(item);
        }

        //Gets items with with specific position
        private Item getItem(Point position)
        {
            foreach (Item i in itemslist)
            {
                if (i.ContainsPoint(position))
                {
                    return i;
                }
            }
            return null;
        }

        public bool RemoveItem(Point position)
        {
            Item i;
            if ((i = getItem(position)) != null)
            {
                itemslist.Remove(i);
                return true;
            }
            
            return false;
        }
        //Connects two items according to two points p1 and p2
        public bool ConnectTwoItems(Point p1, Point p2)
        {
            if (this.getItem(p1) != null && this.getItem(p2) != null)
            {
                this.getItem(p1).AddNeighborToItem(getItem(p2));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ConnectTwoItems(Graphics gr, Item[] items)
        {
            if (items[0] != null && items[1] != null)
            {
                items[0].AddNeighborToItem(items[1]);
                addLine(gr, items);
                
                return true;
            }

            return false;
        }

        public bool removeConnection(Graphics gr, Item from, Item to)
        {
            if (from != null && to != null)
            {
                from.RemoveNeighborFromItem(to);
                //drawLines(gr, from, to, Pens.Red);

                return true;
            }

            return false;
        }

        //should be called in the paint-event at the form
        // draw line between an item and its neighbor
        public void addLine(Graphics gr, Item[] items)
        {
            Point from = new Point(items[0].Position.X + items[0].Width, items[0].Position.Y + items[0].Height / 2);

            int y = (items[0].Position.Y < items[1].Position.Y ? items[1].Position.Y + 15 : items[1].Position.Y + items[1].Height - 15);

            Point to = new Point(items[1].Position.X, y);
            Line line = new Line(from, to);

            items[0].OutLines.Add(line);
            items[1].InLines.Add(line);

            drawLines(gr);
        }

        public void drawLines(Graphics gr)
        {
            Pen pen;
            foreach (Item item in itemslist)
            {
                pen = item.Pen;
                pen.Width = 2.0f;

                foreach (Line line in item.OutLines)
                {
                    gr.DrawLine(pen, line.From, line.To);
                }
            }
        }

        //removes an item from its
        public bool DeleteConnection(Point p)
        {
            Item i;
            if ((i = getItem(p)) != null)
            {
                i.ListOfNeighbors.Remove(i);
                

                // we need to destroy the line 
                return true;
            }
            return false;
        }

        //This method saves Grid state to a file
        public string SaveGridStatusToFile()
        {
            try
            {
                if (this.ItemsList != null)
                {
                    SaverLoader sl1, sl2;
                    sl1 = new SaverLoader(this, "grid.txt");
                    sl1.SaveGridToFile();
                    sl2 = new SaverLoader(this, "neighbour.txt");
                    sl2.SaveInfoAboutNeigbours();
                    return "The grid was saved to a file";
                }
                else
                    return "Grid is empty!";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        //this method restores grid from the file
        public string LoadGridStatusFromFile()
        {
            //try
            //{
                SaverLoader sl1, sl2;
                sl1 = new SaverLoader(this, "grid.txt");
                sl1.RestoreGridFromFile();
                sl2 = new SaverLoader(this, "neighbours.txt");
                sl2.LoadInfoAboutNeighbours();
                return "The grid was restored from a file";
            //}
           //catch (Exception e)
            //{
           //     return e.Message;
            //}
        }

        public Item GetItemBySequenceNumber(long sn)
        {
            foreach (Item i in this.ItemsList)
            {
                if (i.SequenceNumber == sn)
                    return i;
            }
            return null;
        }
    }
}