
namespace Prevoz.WinUI.Korisnik
{
    partial class frmVoznjaPublish
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartLokacija = new System.Windows.Forms.TextBox();
            this.lblDatumVoznje = new System.Windows.Forms.Label();
            this.dtpDatumVoznjePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestLokacija = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCijenaSjedista = new System.Windows.Forms.TextBox();
            this.comboBoxVoziloPicker = new System.Windows.Forms.ComboBox();
            this.btnObjavi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.cmbBrojSlobodnihSjedista = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPonistiLatLng = new System.Windows.Forms.Button();
            this.btnPonistiSve = new System.Windows.Forms.Button();
            this.errorProviderVoznjaPublish = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmBAutomatskoOdobrenje = new System.Windows.Forms.ComboBox();
            this.cmbKucniLjubimci = new System.Windows.Forms.ComboBox();
            this.textBoxDetaljnijeInformacije = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCigarete = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVoznjaPublish)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Polazna lokacija";
            // 
            // txtStartLokacija
            // 
            this.txtStartLokacija.Location = new System.Drawing.Point(27, 65);
            this.txtStartLokacija.Name = "txtStartLokacija";
            this.txtStartLokacija.Size = new System.Drawing.Size(411, 20);
            this.txtStartLokacija.TabIndex = 13;
            this.txtStartLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartLokacija_Validating);
            // 
            // lblDatumVoznje
            // 
            this.lblDatumVoznje.AutoSize = true;
            this.lblDatumVoznje.Location = new System.Drawing.Point(256, 290);
            this.lblDatumVoznje.Name = "lblDatumVoznje";
            this.lblDatumVoznje.Size = new System.Drawing.Size(119, 13);
            this.lblDatumVoznje.TabIndex = 18;
            this.lblDatumVoznje.Text = "Odaberite datum vožnje";
            // 
            // dtpDatumVoznjePicker
            // 
            this.dtpDatumVoznjePicker.Location = new System.Drawing.Point(259, 305);
            this.dtpDatumVoznjePicker.Name = "dtpDatumVoznjePicker";
            this.dtpDatumVoznjePicker.Size = new System.Drawing.Size(179, 20);
            this.dtpDatumVoznjePicker.TabIndex = 7;
            this.dtpDatumVoznjePicker.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatumVoznjePicker_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Destinacija";
            // 
            // txtDestLokacija
            // 
            this.txtDestLokacija.Location = new System.Drawing.Point(27, 111);
            this.txtDestLokacija.Name = "txtDestLokacija";
            this.txtDestLokacija.Size = new System.Drawing.Size(411, 20);
            this.txtDestLokacija.TabIndex = 22;
            this.txtDestLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtDestLokacija_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Cijena sjedišta (€)";
            // 
            // txtCijenaSjedista
            // 
            this.txtCijenaSjedista.Location = new System.Drawing.Point(27, 315);
            this.txtCijenaSjedista.Name = "txtCijenaSjedista";
            this.txtCijenaSjedista.Size = new System.Drawing.Size(179, 20);
            this.txtCijenaSjedista.TabIndex = 26;
            this.txtCijenaSjedista.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijenaSjedista_Validating_1);
            // 
            // comboBoxVoziloPicker
            // 
            this.comboBoxVoziloPicker.FormattingEnabled = true;
            this.comboBoxVoziloPicker.Location = new System.Drawing.Point(259, 250);
            this.comboBoxVoziloPicker.Name = "comboBoxVoziloPicker";
            this.comboBoxVoziloPicker.Size = new System.Drawing.Size(179, 21);
            this.comboBoxVoziloPicker.TabIndex = 28;
            this.comboBoxVoziloPicker.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxVoziloPicker_Validating);
            // 
            // btnObjavi
            // 
            this.btnObjavi.Location = new System.Drawing.Point(807, 473);
            this.btnObjavi.Name = "btnObjavi";
            this.btnObjavi.Size = new System.Drawing.Size(110, 23);
            this.btnObjavi.TabIndex = 9;
            this.btnObjavi.Text = "Objavi";
            this.btnObjavi.UseVisualStyleBackColor = true;
            this.btnObjavi.Click += new System.EventHandler(this.btnObjavi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Odaberi vozilo";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(473, 65);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(474, 380);
            this.gmap.TabIndex = 31;
            this.gmap.Zoom = 11D;
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            // 
            // cmbBrojSlobodnihSjedista
            // 
            this.cmbBrojSlobodnihSjedista.FormattingEnabled = true;
            this.cmbBrojSlobodnihSjedista.Location = new System.Drawing.Point(27, 373);
            this.cmbBrojSlobodnihSjedista.Name = "cmbBrojSlobodnihSjedista";
            this.cmbBrojSlobodnihSjedista.Size = new System.Drawing.Size(179, 21);
            this.cmbBrojSlobodnihSjedista.TabIndex = 32;
            this.cmbBrojSlobodnihSjedista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBrojSlobodnihSjedista_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Broj slobodnih sjedišta";
            // 
            // btnPonistiLatLng
            // 
            this.btnPonistiLatLng.Location = new System.Drawing.Point(344, 137);
            this.btnPonistiLatLng.Name = "btnPonistiLatLng";
            this.btnPonistiLatLng.Size = new System.Drawing.Size(94, 23);
            this.btnPonistiLatLng.TabIndex = 34;
            this.btnPonistiLatLng.Text = "Poništi lokaciju";
            this.btnPonistiLatLng.UseVisualStyleBackColor = true;
            this.btnPonistiLatLng.Click += new System.EventHandler(this.btnPonistiLatLng_Click);
            // 
            // btnPonistiSve
            // 
            this.btnPonistiSve.Location = new System.Drawing.Point(30, 473);
            this.btnPonistiSve.Name = "btnPonistiSve";
            this.btnPonistiSve.Size = new System.Drawing.Size(94, 23);
            this.btnPonistiSve.TabIndex = 8;
            this.btnPonistiSve.Text = "Poništi sve";
            this.btnPonistiSve.UseVisualStyleBackColor = true;
            this.btnPonistiSve.Click += new System.EventHandler(this.btnPonistiSve_Click);
            // 
            // errorProviderVoznjaPublish
            // 
            this.errorProviderVoznjaPublish.ContainerControl = this;
            // 
            // cmBAutomatskoOdobrenje
            // 
            this.cmBAutomatskoOdobrenje.FormattingEnabled = true;
            this.cmBAutomatskoOdobrenje.Location = new System.Drawing.Point(27, 193);
            this.cmBAutomatskoOdobrenje.Name = "cmBAutomatskoOdobrenje";
            this.cmBAutomatskoOdobrenje.Size = new System.Drawing.Size(179, 21);
            this.cmBAutomatskoOdobrenje.TabIndex = 35;
            this.cmBAutomatskoOdobrenje.Validating += new System.ComponentModel.CancelEventHandler(this.cmBAutomatskoOdobrenje_Validating);
            // 
            // cmbKucniLjubimci
            // 
            this.cmbKucniLjubimci.FormattingEnabled = true;
            this.cmbKucniLjubimci.Location = new System.Drawing.Point(27, 250);
            this.cmbKucniLjubimci.Name = "cmbKucniLjubimci";
            this.cmbKucniLjubimci.Size = new System.Drawing.Size(179, 21);
            this.cmbKucniLjubimci.TabIndex = 37;
            this.cmbKucniLjubimci.Validating += new System.ComponentModel.CancelEventHandler(this.cmbKucniLjubimci_Validating);
            // 
            // textBoxDetaljnijeInformacije
            // 
            this.textBoxDetaljnijeInformacije.Location = new System.Drawing.Point(259, 373);
            this.textBoxDetaljnijeInformacije.Multiline = true;
            this.textBoxDetaljnijeInformacije.Name = "textBoxDetaljnijeInformacije";
            this.textBoxDetaljnijeInformacije.Size = new System.Drawing.Size(179, 72);
            this.textBoxDetaljnijeInformacije.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Detaljnije informacije";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Automatsko odobrenje vožnje";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Cigarete";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Kućni ljubimci";
            // 
            // cmbCigarete
            // 
            this.cmbCigarete.FormattingEnabled = true;
            this.cmbCigarete.Location = new System.Drawing.Point(259, 193);
            this.cmbCigarete.Name = "cmbCigarete";
            this.cmbCigarete.Size = new System.Drawing.Size(179, 21);
            this.cmbCigarete.TabIndex = 36;
            this.cmbCigarete.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCigarete_Validating);
            // 
            // frmVoznjaPublish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 551);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDetaljnijeInformacije);
            this.Controls.Add(this.cmbKucniLjubimci);
            this.Controls.Add(this.cmbCigarete);
            this.Controls.Add(this.cmBAutomatskoOdobrenje);
            this.Controls.Add(this.btnPonistiSve);
            this.Controls.Add(this.btnPonistiLatLng);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBrojSlobodnihSjedista);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnObjavi);
            this.Controls.Add(this.comboBoxVoziloPicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCijenaSjedista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestLokacija);
            this.Controls.Add(this.lblDatumVoznje);
            this.Controls.Add(this.dtpDatumVoznjePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartLokacija);
            this.Name = "frmVoznjaPublish";
            this.Text = "frmVoznjaPublish";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVoznjaPublish_FormClosing);
            this.Load += new System.EventHandler(this.frmVoznjaPublish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVoznjaPublish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartLokacija;
        private System.Windows.Forms.Label lblDatumVoznje;
        private System.Windows.Forms.DateTimePicker dtpDatumVoznjePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestLokacija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCijenaSjedista;
        private System.Windows.Forms.ComboBox comboBoxVoziloPicker;
        private System.Windows.Forms.Button btnObjavi;
        private System.Windows.Forms.Label label7;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.ComboBox cmbBrojSlobodnihSjedista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPonistiLatLng;
        private System.Windows.Forms.Button btnPonistiSve;
        private System.Windows.Forms.ErrorProvider errorProviderVoznjaPublish;
        private System.Windows.Forms.ComboBox cmbKucniLjubimci;
        private System.Windows.Forms.ComboBox cmBAutomatskoOdobrenje;
        private System.Windows.Forms.TextBox textBoxDetaljnijeInformacije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCigarete;
    }
}