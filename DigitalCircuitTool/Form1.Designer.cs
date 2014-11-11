namespace DigitalCircuitTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbSOURCE1 = new System.Windows.Forms.PictureBox();
            this.pbSINK = new System.Windows.Forms.PictureBox();
            this.pbSOURCE0 = new System.Windows.Forms.PictureBox();
            this.pbAND = new System.Windows.Forms.PictureBox();
            this.pbNOT = new System.Windows.Forms.PictureBox();
            this.pbXOR = new System.Windows.Forms.PictureBox();
            this.pbOR = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSOURCE1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSINK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSOURCE0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbXOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOR)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Controls.Add(this.pbSOURCE1);
            this.groupBox1.Controls.Add(this.pbSINK);
            this.groupBox1.Controls.Add(this.pbSOURCE0);
            this.groupBox1.Controls.Add(this.pbAND);
            this.groupBox1.Controls.Add(this.pbNOT);
            this.groupBox1.Controls.Add(this.pbXOR);
            this.groupBox1.Controls.Add(this.pbOR);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 598);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // pbSOURCE1
            // 
            this.pbSOURCE1.Image = global::DigitalCircuitTool.Properties.Resources.number_1_red_th;
            this.pbSOURCE1.Location = new System.Drawing.Point(31, 318);
            this.pbSOURCE1.Name = "pbSOURCE1";
            this.pbSOURCE1.Size = new System.Drawing.Size(56, 50);
            this.pbSOURCE1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSOURCE1.TabIndex = 8;
            this.pbSOURCE1.TabStop = false;
            // 
            // pbSINK
            // 
            this.pbSINK.Image = global::DigitalCircuitTool.Properties.Resources.lamp;
            this.pbSINK.Location = new System.Drawing.Point(30, 464);
            this.pbSINK.Name = "pbSINK";
            this.pbSINK.Size = new System.Drawing.Size(56, 81);
            this.pbSINK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSINK.TabIndex = 6;
            this.pbSINK.TabStop = false;
            // 
            // pbSOURCE0
            // 
            this.pbSOURCE0.Image = global::DigitalCircuitTool.Properties.Resources.number_0_black_th;
            this.pbSOURCE0.Location = new System.Drawing.Point(31, 387);
            this.pbSOURCE0.Name = "pbSOURCE0";
            this.pbSOURCE0.Size = new System.Drawing.Size(56, 50);
            this.pbSOURCE0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSOURCE0.TabIndex = 5;
            this.pbSOURCE0.TabStop = false;
            // 
            // pbAND
            // 
            this.pbAND.BackgroundImage = global::DigitalCircuitTool.Properties.Resources.AND;
            this.pbAND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAND.Image = global::DigitalCircuitTool.Properties.Resources.AND;
            this.pbAND.Location = new System.Drawing.Point(6, 29);
            this.pbAND.Name = "pbAND";
            this.pbAND.Size = new System.Drawing.Size(100, 50);
            this.pbAND.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAND.TabIndex = 0;
            this.pbAND.TabStop = false;
            // 
            // pbNOT
            // 
            this.pbNOT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbNOT.BackgroundImage")));
            this.pbNOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNOT.Image = global::DigitalCircuitTool.Properties.Resources.NOT;
            this.pbNOT.Location = new System.Drawing.Point(8, 246);
            this.pbNOT.Name = "pbNOT";
            this.pbNOT.Size = new System.Drawing.Size(100, 50);
            this.pbNOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNOT.TabIndex = 3;
            this.pbNOT.TabStop = false;
            // 
            // pbXOR
            // 
            this.pbXOR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbXOR.BackgroundImage")));
            this.pbXOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbXOR.Image = global::DigitalCircuitTool.Properties.Resources.XOR;
            this.pbXOR.Location = new System.Drawing.Point(8, 173);
            this.pbXOR.Name = "pbXOR";
            this.pbXOR.Size = new System.Drawing.Size(100, 50);
            this.pbXOR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbXOR.TabIndex = 2;
            this.pbXOR.TabStop = false;
            // 
            // pbOR
            // 
            this.pbOR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbOR.BackgroundImage")));
            this.pbOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOR.Image = global::DigitalCircuitTool.Properties.Resources.OR;
            this.pbOR.Location = new System.Drawing.Point(8, 100);
            this.pbOR.Name = "pbOR";
            this.pbOR.Size = new System.Drawing.Size(100, 50);
            this.pbOR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOR.TabIndex = 1;
            this.pbOR.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.fileLoadToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.deleteConnectionToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // fileLoadToolStripMenuItem
            // 
            this.fileLoadToolStripMenuItem.Name = "fileLoadToolStripMenuItem";
            this.fileLoadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileLoadToolStripMenuItem.Text = "Load";
            this.fileLoadToolStripMenuItem.Click += new System.EventHandler(this.fileLoadToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // deleteConnectionToolStripMenuItem
            // 
            this.deleteConnectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.deleteConnectionToolStripMenuItem.Name = "deleteConnectionToolStripMenuItem";
            this.deleteConnectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.deleteConnectionToolStripMenuItem.Text = "Connection";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem2.Text = "Help";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DigitalCircuitTool.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(863, 637);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSOURCE1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSINK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSOURCE0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbXOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOR)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbNOT;
        private System.Windows.Forms.PictureBox pbXOR;
        private System.Windows.Forms.PictureBox pbOR;
        private System.Windows.Forms.PictureBox pbAND;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PictureBox pbSOURCE0;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbSINK;
        private System.Windows.Forms.PictureBox pbSOURCE1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem deleteConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
    }
}

