
namespace Prevoz.WinUI.Korisnik
{
    partial class frmVoznjaSearch
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
            this.groupBoxListaVoznji = new System.Windows.Forms.GroupBox();
            this.dgvVoznje = new System.Windows.Forms.DataGridView();
            this.VoznjaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rezervisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CijenaSjedista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojSjedista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.korisnikIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slikaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.korisnikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voznjaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtStartLokacija = new System.Windows.Forms.TextBox();
            this.dtpDatumVoznjePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDatumVoznje = new System.Windows.Forms.Label();
            this.txtDestLokacija = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPonistiLatLng = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProviderVoznjaSearch = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxListaVoznji.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoznje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voznjaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVoznjaSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxListaVoznji
            // 
            this.groupBoxListaVoznji.Controls.Add(this.dgvVoznje);
            this.groupBoxListaVoznji.Location = new System.Drawing.Point(109, 250);
            this.groupBoxListaVoznji.Name = "groupBoxListaVoznji";
            this.groupBoxListaVoznji.Size = new System.Drawing.Size(546, 188);
            this.groupBoxListaVoznji.TabIndex = 0;
            this.groupBoxListaVoznji.TabStop = false;
            this.groupBoxListaVoznji.Text = "Lista vožnji";
            // 
            // dgvVoznje
            // 
            this.dgvVoznje.AllowUserToAddRows = false;
            this.dgvVoznje.AllowUserToDeleteRows = false;
            this.dgvVoznje.AutoGenerateColumns = false;
            this.dgvVoznje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoznje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.korisnikIdDataGridViewTextBoxColumn,
            this.userName,
            this.slikaDataGridViewTextBoxColumn,
            this.VoznjaId,
            this.Rezervisi,
            this.CijenaSjedista,
            this.BrojSjedista,
            this.Detalji});
            this.dgvVoznje.DataSource = this.korisnikBindingSource;
            this.dgvVoznje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVoznje.Location = new System.Drawing.Point(3, 16);
            this.dgvVoznje.Name = "dgvVoznje";
            this.dgvVoznje.ReadOnly = true;
            this.dgvVoznje.Size = new System.Drawing.Size(540, 169);
            this.dgvVoznje.TabIndex = 0;
            this.dgvVoznje.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoznje_CellContentClick);
            // 
            // VoznjaId
            // 
            this.VoznjaId.DataPropertyName = "VoznjaId";
            this.VoznjaId.HeaderText = "Vožnja";
            this.VoznjaId.Name = "VoznjaId";
            this.VoznjaId.ReadOnly = true;
            this.VoznjaId.Visible = false;
            // 
            // Rezervisi
            // 
            this.Rezervisi.DataPropertyName = "Rezervisi";
            this.Rezervisi.HeaderText = "";
            this.Rezervisi.Name = "Rezervisi";
            this.Rezervisi.ReadOnly = true;
            this.Rezervisi.Text = "Rezerviši";
            this.Rezervisi.UseColumnTextForButtonValue = true;
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "Korisnik";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            // 
            // CijenaSjedista
            // 
            this.CijenaSjedista.DataPropertyName = "CijenaSjedista";
            this.CijenaSjedista.HeaderText = "Cijena jednog sjedišta";
            this.CijenaSjedista.Name = "CijenaSjedista";
            this.CijenaSjedista.ReadOnly = true;
            // 
            // BrojSjedista
            // 
            this.BrojSjedista.DataPropertyName = "BrojSjedista";
            this.BrojSjedista.HeaderText = "Broj slobodnih sjedišta";
            this.BrojSjedista.Name = "BrojSjedista";
            this.BrojSjedista.ReadOnly = true;
            // 
            // korisnikIdDataGridViewTextBoxColumn
            // 
            this.korisnikIdDataGridViewTextBoxColumn.DataPropertyName = "KorisnikId";
            this.korisnikIdDataGridViewTextBoxColumn.HeaderText = "KorisnikId";
            this.korisnikIdDataGridViewTextBoxColumn.Name = "korisnikIdDataGridViewTextBoxColumn";
            this.korisnikIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.korisnikIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "UserName";
            this.userName.HeaderText = "Korisničko ime";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // slikaDataGridViewTextBoxColumn
            // 
            this.slikaDataGridViewTextBoxColumn.DataPropertyName = "Slika";
            this.slikaDataGridViewTextBoxColumn.HeaderText = "Slika";
            this.slikaDataGridViewTextBoxColumn.Name = "slikaDataGridViewTextBoxColumn";
            this.slikaDataGridViewTextBoxColumn.ReadOnly = true;
            this.slikaDataGridViewTextBoxColumn.Visible = false;
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // korisnikBindingSource
            // 
            this.korisnikBindingSource.DataSource = typeof(Prevoz.Model.Korisnik);
            // 
            // voznjaBindingSource
            // 
            this.voznjaBindingSource.DataSource = typeof(Prevoz.Model.Voznja);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(235, 199);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(117, 33);
            this.btnPrikazi.TabIndex = 4;
            this.btnPrikazi.Text = "Prikaži vožnje";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtStartLokacija
            // 
            this.txtStartLokacija.Location = new System.Drawing.Point(236, 25);
            this.txtStartLokacija.Name = "txtStartLokacija";
            this.txtStartLokacija.Size = new System.Drawing.Size(299, 20);
            this.txtStartLokacija.TabIndex = 1;
            this.txtStartLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartLokacija_Validating);
            // 
            // dtpDatumVoznjePicker
            // 
            this.dtpDatumVoznjePicker.Location = new System.Drawing.Point(236, 145);
            this.dtpDatumVoznjePicker.Name = "dtpDatumVoznjePicker";
            this.dtpDatumVoznjePicker.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumVoznjePicker.TabIndex = 3;
            this.dtpDatumVoznjePicker.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatumVoznjePicker_Validating);
            // 
            // lblDatumVoznje
            // 
            this.lblDatumVoznje.AutoSize = true;
            this.lblDatumVoznje.Location = new System.Drawing.Point(233, 128);
            this.lblDatumVoznje.Name = "lblDatumVoznje";
            this.lblDatumVoznje.Size = new System.Drawing.Size(119, 13);
            this.lblDatumVoznje.TabIndex = 8;
            this.lblDatumVoznje.Text = "Odaberite datum vožnje";
            // 
            // txtDestLokacija
            // 
            this.txtDestLokacija.Location = new System.Drawing.Point(236, 84);
            this.txtDestLokacija.Name = "txtDestLokacija";
            this.txtDestLokacija.Size = new System.Drawing.Size(299, 20);
            this.txtDestLokacija.TabIndex = 2;
            this.txtDestLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtDestLokacija_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Destinacija";
            // 
            // btnPonistiLatLng
            // 
            this.btnPonistiLatLng.Location = new System.Drawing.Point(418, 199);
            this.btnPonistiLatLng.Name = "btnPonistiLatLng";
            this.btnPonistiLatLng.Size = new System.Drawing.Size(117, 33);
            this.btnPonistiLatLng.TabIndex = 16;
            this.btnPonistiLatLng.Text = "Poništi";
            this.btnPonistiLatLng.UseVisualStyleBackColor = true;
            this.btnPonistiLatLng.Click += new System.EventHandler(this.btnPonistiLatLng_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Polazna lokacija";
            // 
            // errorProviderVoznjaSearch
            // 
            this.errorProviderVoznjaSearch.ContainerControl = this;
            // 
            // frmVoznjaSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 497);
            this.Controls.Add(this.btnPonistiLatLng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDestLokacija);
            this.Controls.Add(this.lblDatumVoznje);
            this.Controls.Add(this.dtpDatumVoznjePicker);
            this.Controls.Add(this.txtStartLokacija);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.groupBoxListaVoznji);
            this.Name = "frmVoznjaSearch";
            this.Text = "Voznje potraznja";
            this.Load += new System.EventHandler(this.frmVoznjaSearch_Load);
            this.groupBoxListaVoznji.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoznje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voznjaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVoznjaSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxListaVoznji;
        private System.Windows.Forms.DataGridView dgvVoznje;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtStartLokacija;
        private System.Windows.Forms.DateTimePicker dtpDatumVoznjePicker;
        private System.Windows.Forms.Label lblDatumVoznje;
        private System.Windows.Forms.TextBox txtDestLokacija;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPonistiLatLng;
        private System.Windows.Forms.BindingSource voznjaBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource korisnikBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoznjaId;
        private System.Windows.Forms.DataGridViewButtonColumn Rezervisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CijenaSjedista;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojSjedista;
        private System.Windows.Forms.DataGridViewTextBoxColumn korisnikIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn slikaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.ErrorProvider errorProviderVoznjaSearch;
    }
}