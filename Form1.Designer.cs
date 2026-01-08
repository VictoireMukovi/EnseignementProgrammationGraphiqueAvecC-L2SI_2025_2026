namespace ExerciceL3
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNbr1 = new System.Windows.Forms.TextBox();
            this.txtNbr2 = new System.Windows.Forms.TextBox();
            this.rdbtnPlus = new System.Windows.Forms.RadioButton();
            this.rdbtnMoin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "nbr1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "nbr2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "resultat";
            // 
            // txtNbr1
            // 
            this.txtNbr1.Location = new System.Drawing.Point(224, 96);
            this.txtNbr1.Name = "txtNbr1";
            this.txtNbr1.Size = new System.Drawing.Size(270, 26);
            this.txtNbr1.TabIndex = 3;
            // 
            // txtNbr2
            // 
            this.txtNbr2.Location = new System.Drawing.Point(224, 155);
            this.txtNbr2.Name = "txtNbr2";
            this.txtNbr2.Size = new System.Drawing.Size(270, 26);
            this.txtNbr2.TabIndex = 4;
            // 
            // rdbtnPlus
            // 
            this.rdbtnPlus.AutoSize = true;
            this.rdbtnPlus.Location = new System.Drawing.Point(224, 216);
            this.rdbtnPlus.Name = "rdbtnPlus";
            this.rdbtnPlus.Size = new System.Drawing.Size(43, 24);
            this.rdbtnPlus.TabIndex = 6;
            this.rdbtnPlus.TabStop = true;
            this.rdbtnPlus.Text = "+";
            this.rdbtnPlus.UseVisualStyleBackColor = true;
            // 
            // rdbtnMoin
            // 
            this.rdbtnMoin.AutoSize = true;
            this.rdbtnMoin.Location = new System.Drawing.Point(379, 213);
            this.rdbtnMoin.Name = "rdbtnMoin";
            this.rdbtnMoin.Size = new System.Drawing.Size(39, 24);
            this.rdbtnMoin.TabIndex = 7;
            this.rdbtnMoin.TabStop = true;
            this.rdbtnMoin.Text = "-";
            this.rdbtnMoin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 61);
            this.button1.TabIndex = 8;
            this.button1.Text = "calculer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRes
            // 
            this.txtRes.Location = new System.Drawing.Point(269, 360);
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(225, 26);
            this.txtRes.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdbtnMoin);
            this.Controls.Add(this.rdbtnPlus);
            this.Controls.Add(this.txtNbr2);
            this.Controls.Add(this.txtNbr1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNbr1;
        private System.Windows.Forms.TextBox txtNbr2;
        private System.Windows.Forms.TextBox resultat;
        private System.Windows.Forms.RadioButton rdbtnPlus;
        private System.Windows.Forms.RadioButton rdbtnMoin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRes;
    }
}

