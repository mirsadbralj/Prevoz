
namespace Prevoz.WinUI.Korisnik
{
    partial class frmFAQ
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPitanje = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFAQ = new System.Windows.Forms.DataGridView();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.errorProviderFaq = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFAQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFaq)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unesite pitanje:";
            // 
            // txtPitanje
            // 
            this.txtPitanje.Location = new System.Drawing.Point(66, 36);
            this.txtPitanje.Name = "txtPitanje";
            this.txtPitanje.Size = new System.Drawing.Size(335, 42);
            this.txtPitanje.TabIndex = 2;
            this.txtPitanje.Text = "";
            this.txtPitanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtPitanje_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Često postavljena pitanja:";
            // 
            // dgvFAQ
            // 
            this.dgvFAQ.AllowUserToAddRows = false;
            this.dgvFAQ.AllowUserToDeleteRows = false;
            this.dgvFAQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFAQ.Location = new System.Drawing.Point(66, 163);
            this.dgvFAQ.Name = "dgvFAQ";
            this.dgvFAQ.ReadOnly = true;
            this.dgvFAQ.Size = new System.Drawing.Size(335, 267);
            this.dgvFAQ.TabIndex = 4;
            // 
            // btnPosalji
            // 
            this.btnPosalji.Location = new System.Drawing.Point(326, 84);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(75, 23);
            this.btnPosalji.TabIndex = 5;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // errorProviderFaq
            // 
            this.errorProviderFaq.ContainerControl = this;
            // 
            // frmFAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 458);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.dgvFAQ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPitanje);
            this.Controls.Add(this.label1);
            this.Name = "frmFAQ";
            this.Text = "frmFAQ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFAQ_FormClosing);
            this.Load += new System.EventHandler(this.frmFAQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFAQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFaq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtPitanje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFAQ;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.ErrorProvider errorProviderFaq;
    }
}