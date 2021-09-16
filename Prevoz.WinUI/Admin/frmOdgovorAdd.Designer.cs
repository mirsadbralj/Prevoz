
namespace Prevoz.WinUI.Admin
{
    partial class frmOdgovorAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOdgovor = new System.Windows.Forms.RichTextBox();
            this.lblPitanje = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unesi odgovor";
            // 
            // txtOdgovor
            // 
            this.txtOdgovor.Location = new System.Drawing.Point(90, 105);
            this.txtOdgovor.Name = "txtOdgovor";
            this.txtOdgovor.Size = new System.Drawing.Size(267, 96);
            this.txtOdgovor.TabIndex = 2;
            this.txtOdgovor.Text = "";
            // 
            // lblPitanje
            // 
            this.lblPitanje.AutoSize = true;
            this.lblPitanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPitanje.Location = new System.Drawing.Point(87, 38);
            this.lblPitanje.Name = "lblPitanje";
            this.lblPitanje.Size = new System.Drawing.Size(52, 18);
            this.lblPitanje.TabIndex = 3;
            this.lblPitanje.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Potvrdi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOdgovorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPitanje);
            this.Controls.Add(this.txtOdgovor);
            this.Controls.Add(this.label1);
            this.Name = "frmOdgovorAdd";
            this.Text = "frmOdgovorAdd";
            this.Load += new System.EventHandler(this.frmOdgovorAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtOdgovor;
        private System.Windows.Forms.Label lblPitanje;
        private System.Windows.Forms.Button button1;
    }
}