
namespace Prevoz.WinUI.Korisnik
{
    partial class frmKorisnikProfil
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
            this.Potvrda = new System.Windows.Forms.Label();
            this.txtPotvrda = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datumRodenjaPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddVozilo = new System.Windows.Forms.Button();
            this.picBoxSLikaProfila = new System.Windows.Forms.PictureBox();
            this.button2_Click = new System.Windows.Forms.Button();
            this.errorProviderKorisnikProfil = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSLikaProfila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKorisnikProfil)).BeginInit();
            this.SuspendLayout();
            // 
            // Potvrda
            // 
            this.Potvrda.AutoSize = true;
            this.Potvrda.Location = new System.Drawing.Point(181, 309);
            this.Potvrda.Name = "Potvrda";
            this.Potvrda.Size = new System.Drawing.Size(44, 13);
            this.Potvrda.TabIndex = 30;
            this.Potvrda.Text = "Potvrda";
            // 
            // txtPotvrda
            // 
            this.txtPotvrda.Location = new System.Drawing.Point(183, 325);
            this.txtPotvrda.Name = "txtPotvrda";
            this.txtPotvrda.Size = new System.Drawing.Size(132, 20);
            this.txtPotvrda.TabIndex = 8;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(37, 309);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 28;
            this.Password.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(37, 325);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(37, 363);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(132, 24);
            this.btnSacuvaj.TabIndex = 12;
            this.btnSacuvaj.Text = "Sačuvaj izmjene";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(37, 226);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(278, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Korisničko ime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(37, 74);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(278, 20);
            this.txtPrezime.TabIndex = 2;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Prezime";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(37, 121);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Email";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(37, 171);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(278, 20);
            this.txtTelefon.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Telefon";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(37, 30);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(278, 20);
            this.txtIme.TabIndex = 1;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ime";
            // 
            // datumRodenjaPicker
            // 
            this.datumRodenjaPicker.Location = new System.Drawing.Point(37, 276);
            this.datumRodenjaPicker.MaxDate = new System.DateTime(2021, 12, 25, 23, 59, 0, 0);
            this.datumRodenjaPicker.Name = "datumRodenjaPicker";
            this.datumRodenjaPicker.Size = new System.Drawing.Size(200, 20);
            this.datumRodenjaPicker.TabIndex = 6;
            this.datumRodenjaPicker.Value = new System.DateTime(2000, 12, 25, 23, 59, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Datum rođenja";
            // 
            // btnAddVozilo
            // 
            this.btnAddVozilo.Location = new System.Drawing.Point(391, 299);
            this.btnAddVozilo.Name = "btnAddVozilo";
            this.btnAddVozilo.Size = new System.Drawing.Size(233, 38);
            this.btnAddVozilo.TabIndex = 10;
            this.btnAddVozilo.Text = "Dodaj vozilo";
            this.btnAddVozilo.UseVisualStyleBackColor = true;
            this.btnAddVozilo.Click += new System.EventHandler(this.btnAddVozilo_Click);
            // 
            // picBoxSLikaProfila
            // 
            this.picBoxSLikaProfila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxSLikaProfila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxSLikaProfila.Cursor = System.Windows.Forms.Cursors.Default;
            this.picBoxSLikaProfila.Location = new System.Drawing.Point(391, 30);
            this.picBoxSLikaProfila.Name = "picBoxSLikaProfila";
            this.picBoxSLikaProfila.Size = new System.Drawing.Size(233, 198);
            this.picBoxSLikaProfila.TabIndex = 36;
            this.picBoxSLikaProfila.TabStop = false;
            // 
            // button2_Click
            // 
            this.button2_Click.Location = new System.Drawing.Point(391, 254);
            this.button2_Click.Name = "button2_Click";
            this.button2_Click.Size = new System.Drawing.Size(233, 39);
            this.button2_Click.TabIndex = 9;
            this.button2_Click.Text = "Dodaj sliku";
            this.button2_Click.UseVisualStyleBackColor = true;
            this.button2_Click.Click += new System.EventHandler(this.btnDodajSliku);
            // 
            // errorProviderKorisnikProfil
            // 
            this.errorProviderKorisnikProfil.ContainerControl = this;
            // 
            // frmKorisnikProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 427);
            this.Controls.Add(this.button2_Click);
            this.Controls.Add(this.picBoxSLikaProfila);
            this.Controls.Add(this.btnAddVozilo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datumRodenjaPicker);
            this.Controls.Add(this.Potvrda);
            this.Controls.Add(this.txtPotvrda);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSacuvaj);
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
            this.Name = "frmKorisnikProfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmKorisnikProfil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKorisnikProfil_FormClosing);
            this.Load += new System.EventHandler(this.frmKorisnikProfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSLikaProfila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKorisnikProfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Potvrda;
        private System.Windows.Forms.TextBox txtPotvrda;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datumRodenjaPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddVozilo;
        private System.Windows.Forms.PictureBox picBoxSLikaProfila;
        private System.Windows.Forms.Button button2_Click;
        private System.Windows.Forms.ErrorProvider errorProviderKorisnikProfil;
    }
}