
namespace Prevoz.WinUI.Korisnik
{
    partial class frmListaNeocijenjenihVoznjiKorisnika
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
            this.dataGridViewListaNeocijenjenihVoznji = new System.Windows.Forms.DataGridView();
            this.OcijeniVoznju = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DetaljiVoznje = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaNeocijenjenihVoznji)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListaNeocijenjenihVoznji
            // 
            this.dataGridViewListaNeocijenjenihVoznji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListaNeocijenjenihVoznji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OcijeniVoznju,
            this.DetaljiVoznje});
            this.dataGridViewListaNeocijenjenihVoznji.Location = new System.Drawing.Point(192, 64);
            this.dataGridViewListaNeocijenjenihVoznji.Name = "dataGridViewListaNeocijenjenihVoznji";
            this.dataGridViewListaNeocijenjenihVoznji.Size = new System.Drawing.Size(395, 292);
            this.dataGridViewListaNeocijenjenihVoznji.TabIndex = 0;
            this.dataGridViewListaNeocijenjenihVoznji.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListaNeocijenjenihVoznji_CellContentClick);
            // 
            // OcijeniVoznju
            // 
            this.OcijeniVoznju.DataPropertyName = "OcijeniVoznju";
            this.OcijeniVoznju.HeaderText = "";
            this.OcijeniVoznju.Name = "OcijeniVoznju";
            this.OcijeniVoznju.Text = "Ocijeni vožnju";
            this.OcijeniVoznju.UseColumnTextForButtonValue = true;
            // 
            // DetaljiVoznje
            // 
            this.DetaljiVoznje.HeaderText = "";
            this.DetaljiVoznje.Name = "DetaljiVoznje";
            this.DetaljiVoznje.Text = "Detalji vožnje";
            this.DetaljiVoznje.UseColumnTextForButtonValue = true;
            // 
            // frmListaNeocijenjenihVoznjiKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewListaNeocijenjenihVoznji);
            this.Name = "frmListaNeocijenjenihVoznjiKorisnika";
            this.Text = "frmListaNeocijenjenihVoznjiKorisnika";
            this.Load += new System.EventHandler(this.frmListaNeocijenjenihVoznjiKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaNeocijenjenihVoznji)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListaNeocijenjenihVoznji;
        private System.Windows.Forms.DataGridViewButtonColumn OcijeniVoznju;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiVoznje;
    }
}