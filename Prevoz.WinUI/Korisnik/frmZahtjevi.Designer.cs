
namespace Prevoz.WinUI.Korisnik
{
    partial class frmZahtjevi
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
            this.dataGridViewAktivniZahtjevi = new System.Windows.Forms.DataGridView();
            this.Prihvati = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ponisti = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViseInformacija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPrihvaceniZahtjevi = new System.Windows.Forms.DataGridView();
            this.ViseInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewOtkazaniZahtjevi = new System.Windows.Forms.DataGridView();
            this.Vise = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAktivniZahtjevi)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrihvaceniZahtjevi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtkazaniZahtjevi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAktivniZahtjevi
            // 
            this.dataGridViewAktivniZahtjevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAktivniZahtjevi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prihvati,
            this.Ponisti,
            this.ViseInformacija});
            this.dataGridViewAktivniZahtjevi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAktivniZahtjevi.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAktivniZahtjevi.Name = "dataGridViewAktivniZahtjevi";
            this.dataGridViewAktivniZahtjevi.Size = new System.Drawing.Size(546, 203);
            this.dataGridViewAktivniZahtjevi.TabIndex = 0;
            this.dataGridViewAktivniZahtjevi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAktivniZahtjevi_CellContentClick);
            // 
            // Prihvati
            // 
            this.Prihvati.DataPropertyName = "Prihvati";
            this.Prihvati.HeaderText = "";
            this.Prihvati.Name = "Prihvati";
            this.Prihvati.Text = "Prihvati";
            this.Prihvati.UseColumnTextForButtonValue = true;
            // 
            // Ponisti
            // 
            this.Ponisti.DataPropertyName = "Ponisti";
            this.Ponisti.HeaderText = "";
            this.Ponisti.Name = "Ponisti";
            this.Ponisti.Text = "Poništi";
            this.Ponisti.UseColumnTextForButtonValue = true;
            // 
            // ViseInformacija
            // 
            this.ViseInformacija.DataPropertyName = "ViseInformacija";
            this.ViseInformacija.HeaderText = "";
            this.ViseInformacija.Name = "ViseInformacija";
            this.ViseInformacija.Text = "Više informacija";
            this.ViseInformacija.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewAktivniZahtjevi);
            this.groupBox1.Location = new System.Drawing.Point(143, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aktivni zahtjevi";
            // 
            // dataGridViewPrihvaceniZahtjevi
            // 
            this.dataGridViewPrihvaceniZahtjevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrihvaceniZahtjevi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViseInfo});
            this.dataGridViewPrihvaceniZahtjevi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrihvaceniZahtjevi.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewPrihvaceniZahtjevi.Name = "dataGridViewPrihvaceniZahtjevi";
            this.dataGridViewPrihvaceniZahtjevi.Size = new System.Drawing.Size(331, 202);
            this.dataGridViewPrihvaceniZahtjevi.TabIndex = 0;
            this.dataGridViewPrihvaceniZahtjevi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrihvaceniZahtjevi_CellContentClick);
            // 
            // ViseInfo
            // 
            this.ViseInfo.DataPropertyName = "ViseInfo";
            this.ViseInfo.HeaderText = "";
            this.ViseInfo.Name = "ViseInfo";
            this.ViseInfo.Text = "Više informacija";
            this.ViseInfo.UseColumnTextForButtonValue = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewPrihvaceniZahtjevi);
            this.groupBox2.Location = new System.Drawing.Point(242, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 221);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prihvaćeni zahtjevi";
            // 
            // dataGridViewOtkazaniZahtjevi
            // 
            this.dataGridViewOtkazaniZahtjevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOtkazaniZahtjevi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vise});
            this.dataGridViewOtkazaniZahtjevi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOtkazaniZahtjevi.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewOtkazaniZahtjevi.Name = "dataGridViewOtkazaniZahtjevi";
            this.dataGridViewOtkazaniZahtjevi.Size = new System.Drawing.Size(331, 187);
            this.dataGridViewOtkazaniZahtjevi.TabIndex = 0;
            this.dataGridViewOtkazaniZahtjevi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOtkazaniZahtjevi_CellContentClick);
            // 
            // Vise
            // 
            this.Vise.DataPropertyName = "Vise";
            this.Vise.HeaderText = "";
            this.Vise.Name = "Vise";
            this.Vise.Text = "Više informacija";
            this.Vise.UseColumnTextForButtonValue = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewOtkazaniZahtjevi);
            this.groupBox3.Location = new System.Drawing.Point(242, 505);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 206);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Otkazani zahtjevi";
            // 
            // frmZahtjevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 756);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmZahtjevi";
            this.Text = "frmZahtjevi";
            this.Load += new System.EventHandler(this.frmZahtjevi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAktivniZahtjevi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrihvaceniZahtjevi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOtkazaniZahtjevi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAktivniZahtjevi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewPrihvaceniZahtjevi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewOtkazaniZahtjevi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewButtonColumn Prihvati;
        private System.Windows.Forms.DataGridViewButtonColumn Ponisti;
        private System.Windows.Forms.DataGridViewButtonColumn ViseInformacija;
        private System.Windows.Forms.DataGridViewButtonColumn ViseInfo;
        private System.Windows.Forms.DataGridViewButtonColumn Vise;
    }
}