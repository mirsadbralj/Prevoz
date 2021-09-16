
namespace Prevoz.WinUI.Admin
{
    partial class frmPost
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
            this.txtNaslov1 = new System.Windows.Forms.TextBox();
            this.txtNaslov2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_PostHistory = new System.Windows.Forms.DataGridView();
            this.Objavio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PostHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaslov1
            // 
            this.txtNaslov1.Location = new System.Drawing.Point(113, 78);
            this.txtNaslov1.Name = "txtNaslov1";
            this.txtNaslov1.Size = new System.Drawing.Size(325, 20);
            this.txtNaslov1.TabIndex = 0;
            // 
            // txtNaslov2
            // 
            this.txtNaslov2.Location = new System.Drawing.Point(113, 152);
            this.txtNaslov2.Name = "txtNaslov2";
            this.txtNaslov2.Size = new System.Drawing.Size(325, 47);
            this.txtNaslov2.TabIndex = 1;
            this.txtNaslov2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naslov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paragraf";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Potvrdi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_PostHistory);
            this.groupBox1.Location = new System.Drawing.Point(113, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 179);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historije izmjena";
            // 
            // dgv_PostHistory
            // 
            this.dgv_PostHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PostHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Objavio});
            this.dgv_PostHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PostHistory.Location = new System.Drawing.Point(3, 16);
            this.dgv_PostHistory.Name = "dgv_PostHistory";
            this.dgv_PostHistory.Size = new System.Drawing.Size(319, 160);
            this.dgv_PostHistory.TabIndex = 0;
            // 
            // Objavio
            // 
            this.Objavio.HeaderText = "Objavio";
            this.Objavio.Name = "Objavio";
            // 
            // frmPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 478);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaslov2);
            this.Controls.Add(this.txtNaslov1);
            this.Name = "frmPost";
            this.Text = "frmPost";
            this.Load += new System.EventHandler(this.frmPost_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PostHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaslov1;
        private System.Windows.Forms.RichTextBox txtNaslov2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_PostHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objavio;
    }
}