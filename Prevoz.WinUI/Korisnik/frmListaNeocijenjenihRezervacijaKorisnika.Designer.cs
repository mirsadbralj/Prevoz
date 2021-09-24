
namespace Prevoz.WinUI.Korisnik
{
    partial class frmListaNeocijenjenihRezervacijaKorisnika
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
            this.dataGridViewListaNeocijenjenihRezervacija = new System.Windows.Forms.DataGridView();
            this.Ocijeni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DetaljiVoznje = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaNeocijenjenihRezervacija)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListaNeocijenjenihRezervacija
            // 
            this.dataGridViewListaNeocijenjenihRezervacija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListaNeocijenjenihRezervacija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ocijeni,
            this.DetaljiVoznje});
            this.dataGridViewListaNeocijenjenihRezervacija.Location = new System.Drawing.Point(220, 77);
            this.dataGridViewListaNeocijenjenihRezervacija.Name = "dataGridViewListaNeocijenjenihRezervacija";
            this.dataGridViewListaNeocijenjenihRezervacija.Size = new System.Drawing.Size(376, 269);
            this.dataGridViewListaNeocijenjenihRezervacija.TabIndex = 0;
            this.dataGridViewListaNeocijenjenihRezervacija.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListaNeocijenjenihRezervacija_CellContentClick);
            // 
            // Ocijeni
            // 
            this.Ocijeni.HeaderText = "";
            this.Ocijeni.Name = "Ocijeni";
            this.Ocijeni.Text = "Ocijeni";
            this.Ocijeni.UseColumnTextForButtonValue = true;
            // 
            // DetaljiVoznje
            // 
            this.DetaljiVoznje.HeaderText = "";
            this.DetaljiVoznje.Name = "DetaljiVoznje";
            this.DetaljiVoznje.Text = "Detalji vožnje";
            this.DetaljiVoznje.UseColumnTextForButtonValue = true;
            // 
            // frmListaNeocijenjenihRezervacijaKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewListaNeocijenjenihRezervacija);
            this.Name = "frmListaNeocijenjenihRezervacijaKorisnika";
            this.Text = "frmListaNeocijenjenihRezervacijaKorisnika";
            this.Load += new System.EventHandler(this.frmListaNeocijenjenihRezervacijaKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaNeocijenjenihRezervacija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListaNeocijenjenihRezervacija;
        private System.Windows.Forms.DataGridViewButtonColumn Ocijeni;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiVoznje;
    }
}