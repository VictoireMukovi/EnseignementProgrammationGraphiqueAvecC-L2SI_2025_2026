namespace ExerciceL3
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.acceuilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCentraleFrmmain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceuilToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.produitsToolStripMenuItem,
            this.venteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // acceuilToolStripMenuItem
            // 
            this.acceuilToolStripMenuItem.Name = "acceuilToolStripMenuItem";
            this.acceuilToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.acceuilToolStripMenuItem.Text = "Acceuil";
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // produitsToolStripMenuItem
            // 
            this.produitsToolStripMenuItem.Name = "produitsToolStripMenuItem";
            this.produitsToolStripMenuItem.Size = new System.Drawing.Size(63, 22);
            this.produitsToolStripMenuItem.Text = "Produits";
            this.produitsToolStripMenuItem.Click += new System.EventHandler(this.produitsToolStripMenuItem_Click);
            // 
            // venteToolStripMenuItem
            // 
            this.venteToolStripMenuItem.Name = "venteToolStripMenuItem";
            this.venteToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.venteToolStripMenuItem.Text = "Vente";
            this.venteToolStripMenuItem.Click += new System.EventHandler(this.venteToolStripMenuItem_Click);
            // 
            // pnlCentraleFrmmain
            // 
            this.pnlCentraleFrmmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCentraleFrmmain.Location = new System.Drawing.Point(12, 27);
            this.pnlCentraleFrmmain.Name = "pnlCentraleFrmmain";
            this.pnlCentraleFrmmain.Size = new System.Drawing.Size(937, 460);
            this.pnlCentraleFrmmain.TabIndex = 1;
            this.pnlCentraleFrmmain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCentraleFrmmain_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 499);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlCentraleFrmmain);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem acceuilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem venteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlCentraleFrmmain;
    }
}