using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalCircuitTool
{
    public partial class Form1 : Form
    {
        Point downPoint;
        private Controller controller;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            controller = Controller.getController();
            this.AllowDrop = true;

            defaultSetUp();
        }

        private void defaultSetUp()
        {
            foreach (Control control in this.Controls)
            {
                if (control.ToString().StartsWith("System.Windows.Forms.GroupBox"))
                {
                    foreach (Control c in control.Controls)
                    {
                        if (c.GetType().ToString().Equals("System.Windows.Forms.PictureBox"))
                        {
                            c.MouseDown += pictureBox_MouseDown;
                            c.MouseMove += pictureBox_MouseMove;
                            c.MouseUp += pictureBox_MouseUp;
                        }
                    }
                }
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Bitmap))) e.Effect = DragDropEffects.Copy;
        }

        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static bool DestroyIcon(IntPtr handle);



        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox p = (PictureBox)sender;
                p.Tag = p.FindForm().PointToClient(p.Parent.PointToScreen(p.Location));
                downPoint = e.Location;
                p.Parent = this;
                p.BringToFront();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                p.Left += e.X - downPoint.X ;
                p.Top += e.Y - downPoint.Y ;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            Item item = controller.createItem(p.Name, p.Location);

            if (overlap(p))
                p.Location = (Point)p.Tag;

            //creating a copy of the picturebox we try to move
            //TestPB PB = new TestPB();
            item.Size = p.Size;
            item.Image = p.Image;
            item.SizeMode = p.SizeMode;
            item.BorderStyle = p.BorderStyle;

            Control c = GetChildAtPoint(new Point(p.Left -1, p.Top));
            if (c == null) c = this;
            Point newLoc = c.PointToClient(p.Parent.PointToScreen(p.Location));
            item.Parent = c;
            item.Location = newLoc;

            p.Parent.Controls.Add(item); // <-- add new PB to the form!
            p.Location = (Point)p.Tag;
            item.MouseMove += new MouseEventHandler(pictureBox_MouseMoveOnGrid);
            item.MouseDown += new MouseEventHandler(pictureBox_MouseDownOnGrid);
            item.MouseUp += new MouseEventHandler(pictureBox_MouseUpOnGrid);
            
            // put the original back where it started:
            
            // create an Item
            //PB.Item = controller.createItem(p.Name, PB.Location);
        }

        private void pictureBox_MouseDownOnGrid(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Item p = (Item)sender;
                p.Tag = p.Location;
                downPoint = e.Location;
                p.Parent = this;
                p.BringToFront();
            }

            if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Shift) != 0)
            {
                Item p = (Item)sender;

                if (p.BorderStyle == BorderStyle.Fixed3D)
                {
                    p.BorderStyle = BorderStyle.FixedSingle;
                    controller.unselectItem(p);
                }
                else
                {
                    if (controller.prepareConnection(p))
                        p.BorderStyle = BorderStyle.Fixed3D;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                Item p = (Item)sender;
                if (p is Source)
                {
                    Source source = (Source)p;
                    source.changeSourceValue();

                    if (source.Output == true)
                        p.Image = pbSOURCE1.Image;
                    else
                        p.Image = pbSOURCE0.Image;

                    controller.drawLines(this.CreateGraphics());
                }
            }
        }

        private void pictureBox_MouseMoveOnGrid(object sender, MouseEventArgs e)
        {
            Item p = (Item)sender;
            if (e.Button == MouseButtons.Left)
            {
                p.Left += e.X - downPoint.X;
                p.Top += e.Y - downPoint.Y;

                foreach (Line line in p.OutLines)
                {
                    line.From = new Point(p.Location.X+p.Width, p.Location.Y+p.Height/2);
                    this.Refresh();
                    controller.drawLines(this.CreateGraphics());
                }
                foreach (Line line in p.InLines)
                {
                    line.To = new Point(p.Location.X, p.Location.Y+p.Height/2);
                    this.Refresh();
                    controller.drawLines(this.CreateGraphics());
                }
            }
        }

        private void pictureBox_MouseUpOnGrid(object sender, MouseEventArgs e)
        {
            Item p = (Item)sender;

            if (overlap(p))
                p.Location = (Point)p.Tag;
            else
                p.Position = p.Location;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.SaveGrid();
        }

        private void fileLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.LoadGrid();
        }

        private void clearItem()
        {
            PictureBox pb = new PictureBox();
            if (Controls.Contains(pb))
            {
                //pb.Click -= new System.EventHandler(pb.Click());
                Controls.Remove(pb);
                pb.Dispose();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            
            defaultSetUp();
            controller.clearGrid();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.connectTwoItems(this.CreateGraphics());
            controller.drawLines(CreateGraphics());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.removeConnection(this.CreateGraphics());
        }
        public bool overlap(Control p)
        {
            Rectangle sr = new Rectangle(p.Left, p.Top, p.Width, p.Height);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Control && ctrl != p)
                {
                    Rectangle r = new Rectangle(ctrl.Left, ctrl.Top, ctrl.Width, ctrl.Height);
                    if (sr.IntersectsWith(r))
                    {
                        //do your stuff
                        return true;
                    }
                }

            }

            return false;
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = controller.deleteSelectedItem();
            if (pictureBox != null)
            {
                pictureBox.Dispose();
                this.Invalidate();
                this.Refresh();
                Application.DoEvents();
                controller.drawLines(CreateGraphics());
            }
        }
    }
}