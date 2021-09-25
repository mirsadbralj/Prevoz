
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
            this.components = new System.ComponentModel.Container();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.picBoxSlikaProfila = new System.Windows.Forms.PictureBox();
            this.cmbOcjena = new System.Windows.Forms.ComboBox();
            this.errorProviderOcjenaKomentar = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSlikaProfila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOcjenaKomentar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUsername.Location = new System.Drawing.Point(194, 23);
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
            this.label1.Location = new System.Drawing.Point(159, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Odaberi ocjenu";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(272, 203);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 4;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // picBoxSlikaProfila
            // 
            this.picBoxSlikaProfila.Location = new System.Drawing.Point(198, 50);
            this.picBoxSlikaProfila.Name = "picBoxSlikaProfila";
            this.picBoxSlikaProfila.Size = new System.Drawing.Size(60, 50);
            this.picBoxSlikaProfila.TabIndex = 5;
            this.picBoxSlikaProfila.TabStop = false;
            // 
            // cmbOcjena
            // 
            this.cmbOcjena.FormattingEnabled = true;
            this.cmbOcjena.Location = new System.Drawing.Point(187, 147);
            this.cmbOcjena.Name = "cmbOcjena";
            this.cmbOcjena.Size = new System.Drawing.Size(81, 21);
            this.cmbOcjena.TabIndex = 6;
            this.cmbOcjena.Validating += new System.ComponentModel.CancelEventHandler(this.cmbOcjena_Validating);
            // 
            // errorProviderOcjenaKomentar
            // 
            this.errorProviderOcjenaKomentar.ContainerControl = this;
            // 
            // frmOcijeniKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 303);
            this.Controls.Add(this.cmbOcjena);
            this.Controls.Add(this.picBoxSlikaProfila);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmOcijeniKorisnika";
            this.Text = "frmOcijeniKorisnika";
            this.Load += new System.EventHandler(this.frmOcijeniKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSlikaProfila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOcjenaKomentar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.PictureBox picBoxSlikaProfila;
        private System.Windows.Forms.ComboBox cmbOcjena;
        private System.Windows.Forms.ErrorProvider errorProviderOcjenaKomentar;
    }
}