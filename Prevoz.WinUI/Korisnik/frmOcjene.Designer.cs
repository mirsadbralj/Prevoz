
namespace Prevoz.WinUI.Korisnik
{
    partial class frmOcjene
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_mojeOcjene = new System.Windows.Forms.DataGridView();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ProsjcnaOcjena = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOcijeniPreostale = new System.Windows.Forms.DataGridView();
            this.DetaljiVoznje = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvOcjeniPreostale = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvOcijeniPreostaleRezervacije = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.DetaljiRezervacije = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mojeOcjene)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcijeniPreostale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjeniPreostale)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcijeniPreostaleRezervacije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_mojeOcjene);
            this.groupBox1.Location = new System.Drawing.Point(222, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Moje ocjene";
            // 
            // dgv_mojeOcjene
            // 
            this.dgv_mojeOcjene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mojeOcjene.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalji});
            this.dgv_mojeOcjene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_mojeOcjene.Location = new System.Drawing.Point(3, 16);
            this.dgv_mojeOcjene.Name = "dgv_mojeOcjene";
            this.dgv_mojeOcjene.Size = new System.Drawing.Size(344, 205);
            this.dgv_mojeOcjene.TabIndex = 0;
            this.dgv_mojeOcjene.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_mojeOcjene_CellContentClick);
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "";
            this.Detalji.Name = "Detalji";
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(224, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vaša prosječna ocjena je :\r\n";
            // 
            // lbl_ProsjcnaOcjena
            // 
            this.lbl_ProsjcnaOcjena.AutoSize = true;
            this.lbl_ProsjcnaOcjena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ProsjcnaOcjena.Location = new System.Drawing.Point(462, 20);
            this.lbl_ProsjcnaOcjena.Name = "lbl_ProsjcnaOcjena";
            this.lbl_ProsjcnaOcjena.Size = new System.Drawing.Size(66, 24);
            this.lbl_ProsjcnaOcjena.TabIndex = 2;
            this.lbl_ProsjcnaOcjena.Text = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOcijeniPreostale);
            this.groupBox2.Controls.Add(this.dgvOcjeniPreostale);
            this.groupBox2.Location = new System.Drawing.Point(222, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 224);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista neocijenjenih korisnika čije vožnje ste rezervisali";
            // 
            // dgvOcijeniPreostale
            // 
            this.dgvOcijeniPreostale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcijeniPreostale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetaljiVoznje});
            this.dgvOcijeniPreostale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOcijeniPreostale.Location = new System.Drawing.Point(3, 16);
            this.dgvOcijeniPreostale.Name = "dgvOcijeniPreostale";
            this.dgvOcijeniPreostale.Size = new System.Drawing.Size(344, 205);
            this.dgvOcijeniPreostale.TabIndex = 1;
            this.dgvOcijeniPreostale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOcijeniPreostale_CellContentClick);
            // 
            // DetaljiVoznje
            // 
            this.DetaljiVoznje.DataPropertyName = "btnDetalji";
            this.DetaljiVoznje.HeaderText = "";
            this.DetaljiVoznje.Name = "DetaljiVoznje";
            this.DetaljiVoznje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DetaljiVoznje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DetaljiVoznje.Text = "Detalji ";
            this.DetaljiVoznje.UseColumnTextForButtonValue = true;
            // 
            // dgvOcjeniPreostale
            // 
            this.dgvOcjeniPreostale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcjeniPreostale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOcjeniPreostale.Location = new System.Drawing.Point(3, 16);
            this.dgvOcjeniPreostale.Name = "dgvOcjeniPreostale";
            this.dgvOcjeniPreostale.Size = new System.Drawing.Size(344, 205);
            this.dgvOcjeniPreostale.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvOcijeniPreostaleRezervacije);
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Location = new System.Drawing.Point(225, 519);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 224);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista neocijenjenih rezervacija korisnika koji su rezervisali vaše vožnje ";
            // 
            // dgvOcijeniPreostaleRezervacije
            // 
            this.dgvOcijeniPreostaleRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcijeniPreostaleRezervacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetaljiRezervacije});
            this.dgvOcijeniPreostaleRezervacije.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOcijeniPreostaleRezervacije.Location = new System.Drawing.Point(3, 16);
            this.dgvOcijeniPreostaleRezervacije.Name = "dgvOcijeniPreostaleRezervacije";
            this.dgvOcijeniPreostaleRezervacije.Size = new System.Drawing.Size(341, 205);
            this.dgvOcijeniPreostaleRezervacije.TabIndex = 1;
            this.dgvOcijeniPreostaleRezervacije.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOcijeniPreostaleRezervacije_CellContentClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 16);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(341, 205);
            this.dataGridView3.TabIndex = 0;
            // 
            // DetaljiRezervacije
            // 
            this.DetaljiRezervacije.DataPropertyName = "btnDetaljiRezervacije";
            this.DetaljiRezervacije.HeaderText = "";
            this.DetaljiRezervacije.Name = "DetaljiRezervacije";
            this.DetaljiRezervacije.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DetaljiRezervacije.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DetaljiRezervacije.Text = "Detalji ";
            this.DetaljiRezervacije.UseColumnTextForButtonValue = true;
            // 
            // frmOcjene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 760);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_ProsjcnaOcjena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmOcjene";
            this.Text = "frmOcjene";
            this.Load += new System.EventHandler(this.frmOcjene_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mojeOcjene)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcijeniPreostale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjeniPreostale)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcijeniPreostaleRezervacije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_mojeOcjene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ProsjcnaOcjena;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOcjeniPreostale;
        private System.Windows.Forms.DataGridView dgvOcijeniPreostale;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvOcijeniPreostaleRezervacije;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiVoznje;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiRezervacije;
    }
}