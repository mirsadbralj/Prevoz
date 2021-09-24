
namespace Prevoz.WinUI.Admin
{
    partial class frmLeaveFeedback
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
            this.lblKomentar = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxOcjena = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKomentar
            // 
            this.lblKomentar.AutoSize = true;
            this.lblKomentar.Location = new System.Drawing.Point(55, 150);
            this.lblKomentar.Name = "lblKomentar";
            this.lblKomentar.Size = new System.Drawing.Size(52, 13);
            this.lblKomentar.TabIndex = 0;
            this.lblKomentar.Text = "Komentar";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(58, 166);
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(251, 107);
            this.txtKomentar.TabIndex = 2;
            this.txtKomentar.Text = "";
            this.txtKomentar.Validating += new System.ComponentModel.CancelEventHandler(this.txtKomentar_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ocijeni korištenje aplikacije ocjenom od 1 do 5\r\n";
            // 
            // btnPosalji
            // 
            this.btnPosalji.Location = new System.Drawing.Point(228, 305);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(75, 23);
            this.btnPosalji.TabIndex = 3;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBoxOcjena
            // 
            this.comboBoxOcjena.FormattingEnabled = true;
            this.comboBoxOcjena.Location = new System.Drawing.Point(151, 99);
            this.comboBoxOcjena.Name = "comboBoxOcjena";
            this.comboBoxOcjena.Size = new System.Drawing.Size(71, 21);
            this.comboBoxOcjena.TabIndex = 4;
            this.comboBoxOcjena.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxOcjena_Validating);
            // 
            // frmLeaveFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 366);
            this.Controls.Add(this.comboBoxOcjena);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKomentar);
            this.Controls.Add(this.lblKomentar);
            this.Name = "frmLeaveFeedback";
            this.Text = "frmLeaveFeedback";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLeaveFeedback_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKomentar;
        private System.Windows.Forms.RichTextBox txtKomentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBoxOcjena;
    }
}