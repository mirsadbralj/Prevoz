
namespace Prevoz.WinUI.Korisnik
{
    partial class frmOcijeniKorisnika
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.picBoxSlikaProfila = new System.Windows.Forms.PictureBox();
            this.cmbOcjena = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSlikaProfila)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUsername.Location = new System.Drawing.Point(220, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 24);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "label1";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            this.lblUsername.MouseLeave += new System.EventHandler(this.lblUsername_MouseLeave);
            this.lblUsername.MouseHover += new System.EventHandler(this.lblUsername_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(110, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unesi ocjenu za korisnika od 1 do 5";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(328, 194);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 4;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // picBoxSlikaProfila
            // 
            this.picBoxSlikaProfila.Location = new System.Drawing.Point(224, 52);
            this.picBoxSlikaProfila.Name = "picBoxSlikaProfila";
            this.picBoxSlikaProfila.Size = new System.Drawing.Size(60, 50);
            this.picBoxSlikaProfila.TabIndex = 5;
            this.picBoxSlikaProfila.TabStop = false;
            // 
            // cmbOcjena
            // 
            this.cmbOcjena.FormattingEnabled = true;
            this.cmbOcjena.Location = new System.Drawing.Point(205, 159);
            this.cmbOcjena.Name = "cmbOcjena";
            this.cmbOcjena.Size = new System.Drawing.Size(81, 21);
            this.cmbOcjena.TabIndex = 6;
            // 
            // frmOcijeniKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 277);
            this.Controls.Add(this.cmbOcjena);
            this.Controls.Add(this.picBoxSlikaProfila);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmOcijeniKorisnika";
            this.Text = "frmOcijeniKorisnika";
            this.Load += new System.EventHandler(this.frmOcijeniKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSlikaProfila)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.PictureBox picBoxSlikaProfila;
        private System.Windows.Forms.ComboBox cmbOcjena;
    }
}