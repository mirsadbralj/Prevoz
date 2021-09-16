
namespace Prevoz.WinUI.Korisnik
{
    partial class frmPosaljiPoruku
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
            this.dgv_listaPoruka = new System.Windows.Forms.DataGridView();
            this.btnPosaljiPoruku = new System.Windows.Forms.Button();
            this.txtTekstPoruke = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaPoruka)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_listaPoruka);
            this.groupBox1.Location = new System.Drawing.Point(98, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista poruka";
            // 
            // dgv_listaPoruka
            // 
            this.dgv_listaPoruka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listaPoruka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_listaPoruka.Location = new System.Drawing.Point(3, 16);
            this.dgv_listaPoruka.Name = "dgv_listaPoruka";
            this.dgv_listaPoruka.Size = new System.Drawing.Size(455, 334);
            this.dgv_listaPoruka.TabIndex = 0;
            // 
            // btnPosaljiPoruku
            // 
            this.btnPosaljiPoruku.Location = new System.Drawing.Point(462, 399);
            this.btnPosaljiPoruku.Name = "btnPosaljiPoruku";
            this.btnPosaljiPoruku.Size = new System.Drawing.Size(97, 35);
            this.btnPosaljiPoruku.TabIndex = 1;
            this.btnPosaljiPoruku.Text = "Pošalji poruku";
            this.btnPosaljiPoruku.UseVisualStyleBackColor = true;
            this.btnPosaljiPoruku.Click += new System.EventHandler(this.btnPosaljiPoruku_Click);
            // 
            // txtTekstPoruke
            // 
            this.txtTekstPoruke.Location = new System.Drawing.Point(101, 371);
            this.txtTekstPoruke.Multiline = true;
            this.txtTekstPoruke.Name = "txtTekstPoruke";
            this.txtTekstPoruke.Size = new System.Drawing.Size(355, 63);
            this.txtTekstPoruke.TabIndex = 2;
            // 
            // frmPosaljiPoruku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 472);
            this.Controls.Add(this.txtTekstPoruke);
            this.Controls.Add(this.btnPosaljiPoruku);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPosaljiPoruku";
            this.Text = "frmPosaljiPoruku";
            this.Load += new System.EventHandler(this.frmPosaljiPoruku_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaPoruka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_listaPoruka;
        private System.Windows.Forms.Button btnPosaljiPoruku;
        private System.Windows.Forms.TextBox txtTekstPoruke;
    }
}