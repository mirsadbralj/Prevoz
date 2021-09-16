
namespace Prevoz.WinUI.Admin
{
    partial class frmFaq
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
            this.dgvFaq = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Odgovori = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaq)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFaq
            // 
            this.dgvFaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Odgovori});
            this.dgvFaq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaq.Location = new System.Drawing.Point(3, 16);
            this.dgvFaq.Name = "dgvFaq";
            this.dgvFaq.Size = new System.Drawing.Size(508, 278);
            this.dgvFaq.TabIndex = 0;
            this.dgvFaq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaq_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFaq);
            this.groupBox1.Location = new System.Drawing.Point(84, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 297);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista neodgvovorenih pitanja";
            // 
            // Odgovori
            // 
            this.Odgovori.HeaderText = "";
            this.Odgovori.Name = "Odgovori";
            this.Odgovori.Text = "Odgovori";
            this.Odgovori.UseColumnTextForButtonValue = true;
            // 
            // frmFaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 459);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFaq";
            this.Text = "frmFaq";
            this.Load += new System.EventHandler(this.frmFaq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaq)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFaq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewButtonColumn Odgovori;
    }
}