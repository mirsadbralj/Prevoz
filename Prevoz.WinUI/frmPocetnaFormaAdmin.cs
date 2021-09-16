using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WinUI.Admin;
using Prevoz.WinUI.Korisnik;
using Prevoz.WinUI.Reports;
using Prevoz.WinUI.Reports.ReportUplateKorisnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI
{
    public partial class frmPocetnaFormaAdmin : Form
    {
        private int childFormNumber = 0;
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikUloge = new ApiService("korisnikuloge");
        public frmPocetnaFormaAdmin()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ukloniKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaq frm = new frmFaq();
            frm.Show();
        }

        private async void urediPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool AuthorityCheck = false;
            var korisnici = new KorisniciSearchRequest()
            {
                UserName=ApiService.Username
            };
            var korisnik = await _korisnik.Get<List<Model.Korisnik>>(korisnici);

            var korisniciUloge = new KorisnikUlogeSearchRequest() 
            {
                KorisnikId=korisnik[0].KorisnikId
            };

            var korisnikUloge = await _korisnikUloge.Get<List<Model.KorisnikUloge>>(korisniciUloge);


            for (int i = 0; i < korisnikUloge.Count(); i++)
            {
                if (korisnikUloge[i].KorisnikId == korisnik[0].KorisnikId && korisnikUloge[i].UlogaId == 3)
                    AuthorityCheck = true;
            }

            if (AuthorityCheck == true)
            {
                frmUpraviteljUloga frm = new frmUpraviteljUloga();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Upozorenje!", "Ne posjedujete permisije da bi ste pristupili ovoj stranici", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dodajPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPost frm = new frmPost();
            frm.Show();
        }

        private void korisniciDetaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrojRegistrovanihKorisnikaReport frm = new frmBrojRegistrovanihKorisnikaReport();
            frm.Show();
        }

        private void korisniciUplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUplateKorisnikaReport frm = new frmUplateKorisnikaReport();
            frm.Show();
        }
    }
}
