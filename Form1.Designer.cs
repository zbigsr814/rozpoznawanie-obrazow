
namespace okrag
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnZaladuj = new System.Windows.Forms.Button();
            this.btnSprOkrag = new System.Windows.Forms.Button();
            this.btnFProg = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSzary = new System.Windows.Forms.Button();
            this.btnRozmarz = new System.Windows.Forms.Button();
            this.btnWyzSr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(331, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 246);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // btnZaladuj
            // 
            this.btnZaladuj.Location = new System.Drawing.Point(47, 27);
            this.btnZaladuj.Name = "btnZaladuj";
            this.btnZaladuj.Size = new System.Drawing.Size(125, 24);
            this.btnZaladuj.TabIndex = 1;
            this.btnZaladuj.Text = "Załaduj obraz";
            this.btnZaladuj.UseVisualStyleBackColor = true;
            this.btnZaladuj.Click += new System.EventHandler(this.btnZaladuj_Click);
            // 
            // btnSprOkrag
            // 
            this.btnSprOkrag.Location = new System.Drawing.Point(47, 175);
            this.btnSprOkrag.Name = "btnSprOkrag";
            this.btnSprOkrag.Size = new System.Drawing.Size(125, 24);
            this.btnSprOkrag.TabIndex = 2;
            this.btnSprOkrag.Text = "Sprawdź okrągłość";
            this.btnSprOkrag.UseVisualStyleBackColor = true;
            this.btnSprOkrag.Click += new System.EventHandler(this.btnSprOkrag_Click);
            // 
            // btnFProg
            // 
            this.btnFProg.Location = new System.Drawing.Point(47, 116);
            this.btnFProg.Name = "btnFProg";
            this.btnFProg.Size = new System.Drawing.Size(125, 24);
            this.btnFProg.TabIndex = 3;
            this.btnFProg.Text = "Filtr progowy";
            this.btnFProg.UseVisualStyleBackColor = true;
            this.btnFProg.Click += new System.EventHandler(this.btnFProg_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(582, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 4;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(582, 38);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pozycja x:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pozycja y:";
            // 
            // btnSzary
            // 
            this.btnSzary.Location = new System.Drawing.Point(47, 57);
            this.btnSzary.Name = "btnSzary";
            this.btnSzary.Size = new System.Drawing.Size(125, 24);
            this.btnSzary.TabIndex = 8;
            this.btnSzary.Text = "Utwórz szary";
            this.btnSzary.UseVisualStyleBackColor = true;
            this.btnSzary.Click += new System.EventHandler(this.btnSzary_Click);
            // 
            // btnRozmarz
            // 
            this.btnRozmarz.Location = new System.Drawing.Point(47, 87);
            this.btnRozmarz.Name = "btnRozmarz";
            this.btnRozmarz.Size = new System.Drawing.Size(125, 23);
            this.btnRozmarz.TabIndex = 9;
            this.btnRozmarz.Text = "Rozmarz obraz";
            this.btnRozmarz.UseVisualStyleBackColor = true;
            this.btnRozmarz.Click += new System.EventHandler(this.btnRozmarz_Click);
            // 
            // btnWyzSr
            // 
            this.btnWyzSr.Location = new System.Drawing.Point(47, 146);
            this.btnWyzSr.Name = "btnWyzSr";
            this.btnWyzSr.Size = new System.Drawing.Size(136, 23);
            this.btnWyzSr.TabIndex = 10;
            this.btnWyzSr.Text = "Wyznacz środki figur";
            this.btnWyzSr.UseVisualStyleBackColor = true;
            this.btnWyzSr.Click += new System.EventHandler(this.btnWyzSr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWyzSr);
            this.Controls.Add(this.btnRozmarz);
            this.Controls.Add(this.btnSzary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnFProg);
            this.Controls.Add(this.btnSprOkrag);
            this.Controls.Add(this.btnZaladuj);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnZaladuj;
        private System.Windows.Forms.Button btnSprOkrag;
        private System.Windows.Forms.Button btnFProg;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSzary;
        private System.Windows.Forms.Button btnRozmarz;
        private System.Windows.Forms.Button btnWyzSr;
    }
}

