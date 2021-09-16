
namespace Prevoz.WinUI.Korisnik
{
    partial class frmVoziloAdd
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
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.picBoxSLikaProfila = new System.Windows.Forms.PictureBox();
            this.cmB_MarkaVozila = new System.Windows.Forms.ComboBox();
            this.lbl_MarkaVozila = new System.Windows.Forms.Label();
            this.txtNazvVozila = new System.Windows.Forms.TextBox();
            this.lbl_NazivVozila = new System.Windows.Forms.Label();
            this.cmB_Boja = new System.Windows.Forms.ComboBox();
            this.lbl_Boja = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.dgv_ListaVozila = new System.Windows.Forms.DataGridView();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gpBox_ListaVozila = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSLikaProfila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaVozila)).BeginInit();
            this.gpBox_ListaVozila.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(592, 262);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(233, 39);
            this.btnDodajSliku.TabIndex = 1;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // picBoxSLikaProfila
            // 
            this.picBoxSLikaProfila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxSLikaProfila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxSLikaProfila.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBoxSLikaProfila.Location = new System.Drawing.Point(592, 56);
            this.picBoxSLikaProfila.Name = "picBoxSLikaProfila";
            this.picBoxSLikaProfila.Size = new System.Drawing.Size(233, 198);
            this.picBoxSLikaProfila.TabIndex = 38;
            this.picBoxSLikaProfila.TabStop = false;
            // 
            // cmB_MarkaVozila
            // 
            this.cmB_MarkaVozila.FormattingEnabled = true;
            this.cmB_MarkaVozila.Location = new System.Drawing.Point(592, 320);
            this.cmB_MarkaVozila.Name = "cmB_MarkaVozila";
            this.cmB_MarkaVozila.Size = new System.Drawing.Size(233, 21);
            this.cmB_MarkaVozila.TabIndex = 2;
            this.cmB_MarkaVozila.Validating += new System.ComponentModel.CancelEventHandler(this.cmB_MarkaVozila_Validating);
            // 
            // lbl_MarkaVozila
            // 
            this.lbl_MarkaVozila.AutoSize = true;
            this.lbl_MarkaVozila.Location = new System.Drawing.Point(592, 304);
            this.lbl_MarkaVozila.Name = "lbl_MarkaVozila";
            this.lbl_MarkaVozila.Size = new System.Drawing.Size(67, 13);
            this.lbl_MarkaVozila.TabIndex = 41;
            this.lbl_MarkaVozila.Text = "Marka vozila";
            // 
            // txtNazvVozila
            // 
            this.txtNazvVozila.Location = new System.Drawing.Point(592, 370);
            this.txtNazvVozila.Name = "txtNazvVozila";
            this.txtNazvVozila.Size = new System.Drawing.Size(233, 20);
            this.txtNazvVozila.TabIndex = 3;
            this.txtNazvVozila.Validating += new System.ComponentModel.CancelEventHandler(this.txtNazvVozila_Validating);
            // 
            // lbl_NazivVozila
            // 
            this.lbl_NazivVozila.AutoSize = true;
            this.lbl_NazivVozila.Location = new System.Drawing.Point(592, 354);
            this.lbl_NazivVozila.Name = "lbl_NazivVozila";
            this.lbl_NazivVozila.Size = new System.Drawing.Size(37, 13);
            this.lbl_NazivVozila.TabIndex = 43;
            this.lbl_NazivVozila.Text = "Naziv ";
            // 
            // cmB_Boja
            // 
            this.cmB_Boja.FormattingEnabled = true;
            this.cmB_Boja.Location = new System.Drawing.Point(592, 420);
            this.cmB_Boja.Name = "cmB_Boja";
            this.cmB_Boja.Size = new System.Drawing.Size(230, 21);
            this.cmB_Boja.TabIndex = 4;
            this.cmB_Boja.Validating += new System.ComponentModel.CancelEventHandler(this.cmB_Boja_Validating);
            // 
            // lbl_Boja
            // 
            this.lbl_Boja.AutoSize = true;
            this.lbl_Boja.Location = new System.Drawing.Point(592, 404);
            this.lbl_Boja.Name = "lbl_Boja";
            this.lbl_Boja.Size = new System.Drawing.Size(28, 13);
            this.lbl_Boja.TabIndex = 45;
            this.lbl_Boja.Text = "Boja";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(747, 464);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 5;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // dgv_ListaVozila
            // 
            this.dgv_ListaVozila.AllowUserToAddRows = false;
            this.dgv_ListaVozila.AllowUserToDeleteRows = false;
            this.dgv_ListaVozila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListaVozila.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ukloni});
            this.dgv_ListaVozila.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ListaVozila.Location = new System.Drawing.Point(3, 16);
            this.dgv_ListaVozila.Name = "dgv_ListaVozila";
            this.dgv_ListaVozila.ReadOnly = true;
            this.dgv_ListaVozila.RowTemplate.Height = 60;
            this.dgv_ListaVozila.Size = new System.Drawing.Size(540, 382);
            this.dgv_ListaVozila.TabIndex = 47;
            this.dgv_ListaVozila.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ListaVozila_CellContentClick);
            // 
            // Ukloni
            // 
            this.Ukloni.DataPropertyName = "Ukloni";
            this.Ukloni.HeaderText = "";
            this.Ukloni.Name = "Ukloni";
            this.Ukloni.ReadOnly = true;
            this.Ukloni.Text = "Ukloni";
            this.Ukloni.UseColumnTextForButtonValue = true;
            // 
            // gpBox_ListaVozila
            // 
            this.gpBox_ListaVozila.Controls.Add(this.dgv_ListaVozila);
            this.gpBox_ListaVozila.Location = new System.Drawing.Point(24, 40);
            this.gpBox_ListaVozila.Name = "gpBox_ListaVozila";
            this.gpBox_ListaVozila.Size = new System.Drawing.Size(546, 401);
            this.gpBox_ListaVozila.TabIndex = 48;
            this.gpBox_ListaVozila.TabStop = false;
            this.gpBox_ListaVozila.Text = "Lista vozila";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(601, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Želite dodati novo vozilo?";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVoziloAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpBox_ListaVozila);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.lbl_Boja);
            this.Controls.Add(this.cmB_Boja);
            this.Controls.Add(this.lbl_NazivVozila);
            this.Controls.Add(this.txtNazvVozila);
            this.Controls.Add(this.lbl_MarkaVozila);
            this.Controls.Add(this.cmB_MarkaVozila);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.picBoxSLikaProfila);
            this.Name = "frmVoziloAdd";
            this.Text = "frmVozilo";
            this.Load += new System.EventHandler(this.frmVozilo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSLikaProfila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaVozila)).EndInit();
            this.gpBox_ListaVozila.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.PictureBox picBoxSLikaProfila;
        private System.Windows.Forms.ComboBox cmB_MarkaVozila;
        private System.Windows.Forms.Label lbl_MarkaVozila;
        private System.Windows.Forms.TextBox txtNazvVozila;
        private System.Windows.Forms.Label lbl_NazivVozila;
        private System.Windows.Forms.ComboBox cmB_Boja;
        private System.Windows.Forms.Label lbl_Boja;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.DataGridView dgv_ListaVozila;
        private System.Windows.Forms.GroupBox gpBox_ListaVozila;
        private System.Windows.Forms.DataGridViewButtonColumn Ukloni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}