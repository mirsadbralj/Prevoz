
namespace Prevoz.WinUI
{
    partial class frmPocetnaFormaAdmin
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.postoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvještajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciDetaljiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciUplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 499);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postoviToolStripMenuItem,
            this.korisnikToolStripMenuItem,
            this.fAQToolStripMenuItem,
            this.izvještajiToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1110, 29);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // postoviToolStripMenuItem
            // 
            this.postoviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajPostToolStripMenuItem,
            this.urediPostToolStripMenuItem});
            this.postoviToolStripMenuItem.Name = "postoviToolStripMenuItem";
            this.postoviToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.postoviToolStripMenuItem.Text = "Postavke";
            // 
            // dodajPostToolStripMenuItem
            // 
            this.dodajPostToolStripMenuItem.Name = "dodajPostToolStripMenuItem";
            this.dodajPostToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.dodajPostToolStripMenuItem.Text = "Upravitelj postovima";
            this.dodajPostToolStripMenuItem.Click += new System.EventHandler(this.dodajPostToolStripMenuItem_Click);
            // 
            // urediPostToolStripMenuItem
            // 
            this.urediPostToolStripMenuItem.Name = "urediPostToolStripMenuItem";
            this.urediPostToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.urediPostToolStripMenuItem.Text = "Upravitelj uloga";
            this.urediPostToolStripMenuItem.Click += new System.EventHandler(this.urediPostToolStripMenuItem_Click);
            // 
            // korisnikToolStripMenuItem
            // 
            this.korisnikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem});
            this.korisnikToolStripMenuItem.Name = "korisnikToolStripMenuItem";
            this.korisnikToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.korisnikToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem});
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.fAQToolStripMenuItem.Text = "FAQ";
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.pregledToolStripMenuItem.Text = "Pregled";
            this.pregledToolStripMenuItem.Click += new System.EventHandler(this.pregledToolStripMenuItem_Click);
            // 
            // izvještajiToolStripMenuItem
            // 
            this.izvještajiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciDetaljiToolStripMenuItem,
            this.korisniciUplateToolStripMenuItem});
            this.izvještajiToolStripMenuItem.Name = "izvještajiToolStripMenuItem";
            this.izvještajiToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.izvještajiToolStripMenuItem.Text = "Izvještaji";
            // 
            // korisniciDetaljiToolStripMenuItem
            // 
            this.korisniciDetaljiToolStripMenuItem.Name = "korisniciDetaljiToolStripMenuItem";
            this.korisniciDetaljiToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.korisniciDetaljiToolStripMenuItem.Text = "Korisnici - Broj registrovanih";
            this.korisniciDetaljiToolStripMenuItem.Click += new System.EventHandler(this.korisniciDetaljiToolStripMenuItem_Click);
            // 
            // korisniciUplateToolStripMenuItem
            // 
            this.korisniciUplateToolStripMenuItem.Name = "korisniciUplateToolStripMenuItem";
            this.korisniciUplateToolStripMenuItem.Size = new System.Drawing.Size(293, 26);
            this.korisniciUplateToolStripMenuItem.Text = "Korisnici - Uplate";
            this.korisniciUplateToolStripMenuItem.Click += new System.EventHandler(this.korisniciUplateToolStripMenuItem_Click);
            // 
            // frmPocetnaFormaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 521);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPocetnaFormaAdmin";
            this.Text = "frmPocetnaForma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem korisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediPostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvještajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciDetaljiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciUplateToolStripMenuItem;
    }
}



