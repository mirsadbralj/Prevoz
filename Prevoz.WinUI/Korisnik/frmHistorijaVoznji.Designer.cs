
namespace Prevoz.WinUI.Korisnik
{
    partial class frmHistorijaVoznji
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHistorijaRezervisanihVoznji = new System.Windows.Forms.DataGridView();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvHistorijaPonudenihVoznji = new System.Windows.Forms.DataGridView();
            this.DetaljiVoznje = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaRezervisanihVoznji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaPonudenihVoznji)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(250, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Historija rezervisanih vožnji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(250, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Historija ponuđenih vožnji";
            // 
            // dgvHistorijaRezervisanihVoznji
            // 
            this.dgvHistorijaRezervisanihVoznji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorijaRezervisanihVoznji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalji});
            this.dgvHistorijaRezervisanihVoznji.Location = new System.Drawing.Point(148, 98);
            this.dgvHistorijaRezervisanihVoznji.Name = "dgvHistorijaRezervisanihVoznji";
            this.dgvHistorijaRezervisanihVoznji.Size = new System.Drawing.Size(440, 243);
            this.dgvHistorijaRezervisanihVoznji.TabIndex = 2;
            this.dgvHistorijaRezervisanihVoznji.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorijaRezervisanihVoznji_CellContentClick);
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "";
            this.Detalji.Name = "Detalji";
            this.Detalji.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // dgvHistorijaPonudenihVoznji
            // 
            this.dgvHistorijaPonudenihVoznji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorijaPonudenihVoznji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetaljiVoznje});
            this.dgvHistorijaPonudenihVoznji.Location = new System.Drawing.Point(148, 428);
            this.dgvHistorijaPonudenihVoznji.Name = "dgvHistorijaPonudenihVoznji";
            this.dgvHistorijaPonudenihVoznji.Size = new System.Drawing.Size(440, 262);
            this.dgvHistorijaPonudenihVoznji.TabIndex = 3;
            this.dgvHistorijaPonudenihVoznji.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorijaPonudenihVoznji_CellContentClick);
            // 
            // DetaljiVoznje
            // 
            this.DetaljiVoznje.DataPropertyName = "Detalji";
            this.DetaljiVoznje.HeaderText = "";
            this.DetaljiVoznje.Name = "DetaljiVoznje";
            this.DetaljiVoznje.Text = "Detalji";
            this.DetaljiVoznje.UseColumnTextForButtonValue = true;
            // 
            // frmHistorijaVoznji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 726);
            this.Controls.Add(this.dgvHistorijaPonudenihVoznji);
            this.Controls.Add(this.dgvHistorijaRezervisanihVoznji);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmHistorijaVoznji";
            this.Text = "frmHistorijaVoznji";
            this.Load += new System.EventHandler(this.frmHistorijaVoznji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaRezervisanihVoznji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorijaPonudenihVoznji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHistorijaRezervisanihVoznji;
        private System.Windows.Forms.DataGridView dgvHistorijaPonudenihVoznji;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiVoznje;
    }
}