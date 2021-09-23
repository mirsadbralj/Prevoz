using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WinUI.Korisnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI
{
    public partial class frmPocetnaFormaKorisnik : Form
    {
        private readonly ApiService _service = new ApiService("korisnik");
        private readonly ApiService _korisnikUloge = new ApiService("korisnikuloge");
        private readonly ApiService _uloge = new ApiService("uloge");
        private readonly ApiService _post = new ApiService("post");
        private int childFormNumber = 0;

        public frmPocetnaFormaKorisnik()
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
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnikProfil frm = new frmKorisnikProfil();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnVoznjePretraga_Click(object sender, EventArgs e)
        {
            frmVoznjaSearch frm = new frmVoznjaSearch();
            frm.Show();
        }
        private void btnPonudiPrevoz_Click(object sender, EventArgs e)
        {
            frmVoznjaPublish frm = new frmVoznjaPublish();
            frm.Show();
        }
        private async void frmPocetnaFormaKorisnik_Load(object sender, EventArgs e)
        {
            var request = new KorisniciSearchRequest() {UserName = ApiService.Username};
            var korisnik = await _service.Get<List<Model.Korisnik>>(request);

            var _id = korisnik[0].KorisnikId;
            var requestKU = new KorisnikUlogeSearchRequest(){KorisnikId = korisnik[0].KorisnikId};
            var listKorisnikUloge = await _korisnikUloge.Get<List<Model.KorisnikUloge>>(requestKU);

            var listPosts = await _post.Get<List<Model.Post>>(null);

            var requestU = new UlogeSearchRequest()
            {
                UlogaId = requestKU.UlogaId,
            };
            var listUloge = await _uloge.Get<List<Model.Uloge>>(requestU);

            Model.Uloge uloga = new Model.Uloge();
            bool admin = false;
            for (int i = 0; i < listKorisnikUloge.Count(); i++)
            {
                if (listKorisnikUloge[i].KorisnikId == korisnik[0].KorisnikId && listKorisnikUloge[i].UlogaId == 1 || listKorisnikUloge[i].UlogaId==3)
                    admin = true;
            }
            if (admin == false)
                btnAdmin.Visible = false;
            else
                btnAdmin.Visible = true;


            int index = (listPosts.Count() - 1);
            if (index >= 0)
            {
                lblNaslov1.Visible = true;
                lblNaslov2.Visible = true;

                lblNaslov1.Text = listPosts[index].Title;
                lblNaslov2.Text = listPosts[index].Body;
            }
            ust_MenuProfilePicture.Text = korisnik[0].UserName;
        }
        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {this.Close(); frmLogin frm = new frmLogin(); frm.Show();}
        private void vozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {frmVoziloAdd frm = new frmVoziloAdd(); frm.Show();}
        private void historijaToolStripMenuItem_Click(object sender, EventArgs e)
        {frmHistorijaVoznji frm = new frmHistorijaVoznji(); frm.Show();}
        private void ocjeneToolStripMenuItem_Click(object sender, EventArgs e)
        {frmOcjene frm = new frmOcjene(); frm.Show();}
        private void button1_Click(object sender, EventArgs e)
        {frmPocetnaFormaAdmin frm = new frmPocetnaFormaAdmin(); frm.Show();}
        private void čestoPostavljenaPitanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {frmFAQ frm = new frmFAQ(); frm.Show(); }

        private void zahtjeviZaVožnjuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZahtjevi frm = new frmZahtjevi();
            frm.Show();
        }
    }
}
