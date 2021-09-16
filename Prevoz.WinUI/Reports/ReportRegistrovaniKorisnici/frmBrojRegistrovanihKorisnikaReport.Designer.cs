
namespace Prevoz.WinUI.Reports
{
    partial class frmBrojRegistrovanihKorisnikaReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBoxGodine = new System.Windows.Forms.ComboBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.cmBLokacija = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Prevoz.WinUI.Reports.ReportRegistrovaniKorisnici.rptBrojRegistrovanihkorisnika.rd" +
    "lc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // comboBoxGodine
            // 
            this.comboBoxGodine.FormattingEnabled = true;
            this.comboBoxGodine.Location = new System.Drawing.Point(538, 30);
            this.comboBoxGodine.Name = "comboBoxGodine";
            this.comboBoxGodine.Size = new System.Drawing.Size(153, 21);
            this.comboBoxGodine.TabIndex = 1;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(716, 28);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 2;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // cmBLokacija
            // 
            this.cmBLokacija.FormattingEnabled = true;
            this.cmBLokacija.Location = new System.Drawing.Point(300, 30);
            this.cmBLokacija.Name = "cmBLokacija";
            this.cmBLokacija.Size = new System.Drawing.Size(153, 21);
            this.cmBLokacija.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lokacija";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Godina";
            // 
            // frmBrojRegistrovanihKorisnikaReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmBLokacija);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.comboBoxGodine);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmBrojRegistrovanihKorisnikaReport";
            this.Text = "frmBrojRegistrovanihKorisnikaReport";
            this.Load += new System.EventHandler(this.frmBrojRegistrovanihKorisnikaReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBoxGodine;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.ComboBox cmBLokacija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}