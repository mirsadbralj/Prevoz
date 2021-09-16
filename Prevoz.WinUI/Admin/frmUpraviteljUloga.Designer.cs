
namespace Prevoz.WinUI.Admin
{
    partial class frmUpraviteljUloga
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
            this.dgvUpraviteljUloga = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPostaviAdmin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRemoveRole = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpraviteljUloga)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUpraviteljUloga
            // 
            this.dgvUpraviteljUloga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpraviteljUloga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnPostaviAdmin,
            this.btnRemoveRole});
            this.dgvUpraviteljUloga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpraviteljUloga.Location = new System.Drawing.Point(3, 16);
            this.dgvUpraviteljUloga.Name = "dgvUpraviteljUloga";
            this.dgvUpraviteljUloga.Size = new System.Drawing.Size(507, 268);
            this.dgvUpraviteljUloga.TabIndex = 0;
            this.dgvUpraviteljUloga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpraviteljUloga_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUpraviteljUloga);
            this.groupBox1.Location = new System.Drawing.Point(136, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista korisnika i njihove uloge";
            // 
            // btnPostaviAdmin
            // 
            this.btnPostaviAdmin.DataPropertyName = "btnPostaviAdmin";
            this.btnPostaviAdmin.HeaderText = "";
            this.btnPostaviAdmin.Name = "btnPostaviAdmin";
            this.btnPostaviAdmin.Text = "Dodijeli Head Admin permisije";
            this.btnPostaviAdmin.UseColumnTextForButtonValue = true;
            // 
            // btnRemoveRole
            // 
            this.btnRemoveRole.DataPropertyName = "btnRemoveRole";
            this.btnRemoveRole.HeaderText = "";
            this.btnRemoveRole.Name = "btnRemoveRole";
            this.btnRemoveRole.Text = "Ukloni permisije";
            this.btnRemoveRole.UseColumnTextForButtonValue = true;
            // 
            // frmUpraviteljUloga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUpraviteljUloga";
            this.Text = "frmUpraviteljUloga";
            this.Load += new System.EventHandler(this.frmUpraviteljUloga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpraviteljUloga)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUpraviteljUloga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewButtonColumn btnPostaviAdmin;
        private System.Windows.Forms.DataGridViewButtonColumn btnRemoveRole;
    }
}