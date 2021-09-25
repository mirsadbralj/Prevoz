
namespace Prevoz.WinUI.Korisnik
{
    partial class frmKorisniciDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.txtPotvrda = new System.Windows.Forms.TextBox();
            this.Potvrda = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(15, 25);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(278, 20);
            this.txtIme.TabIndex = 1;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(15, 166);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(278, 20);
            this.txtTelefon.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefon";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(15, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(15, 69);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(278, 20);
            this.txtPrezime.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Prezime";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(15, 221);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(278, 20);
            this.txtUserName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Korisničko ime";
            // 
            // btnUkloni
            // 
            this.btnUkloni.Location = new System.Drawing.Point(162, 323);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(131, 23);
            this.btnUkloni.TabIndex = 10;
            this.btnUkloni.Text = "Ukloni korisnika";
            this.btnUkloni.UseVisualStyleBackColor = true;
            this.btnUkloni.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(15, 323);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(131, 23);
            this.btnSacuvaj.TabIndex = 11;
            this.btnSacuvaj.Text = "Sačuvaj izmjene";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 271);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(15, 255);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 13;
            this.Password.Text = "Password";
            // 
            // txtPotvrda
            // 
            this.txtPotvrda.Location = new System.Drawing.Point(161, 271);
            this.txtPotvrda.Name = "txtPotvrda";
            this.txtPotvrda.Size = new System.Drawing.Size(132, 20);
            this.txtPotvrda.TabIndex = 14;
            // 
            // Potvrda
            // 
            this.Potvrda.AutoSize = true;
            this.Potvrda.Location = new System.Drawing.Point(159, 255);
            this.Potvrda.Name = "Potvrda";
            this.Potvrda.Size = new System.Drawing.Size(44, 13);
            this.Potvrda.TabIndex = 15;
            this.Potvrda.Text = "Potvrda";
            // 
            // frmKorisniciDetail
            // 
            this.ClientSize = new System.Drawing.Size(319, 363);
            this.Controls.Add(this.Potvrda);
            this.Controls.Add(this.txtPotvrda);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label2);
            this.Name = "frmKorisniciDetail";
            this.Load += new System.EventHandler(this.frmKorisniciDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox txtPotvrda;
        private System.Windows.Forms.Label Potvrda;
    }
}