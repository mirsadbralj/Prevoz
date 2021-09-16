using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Admin
{
    public partial class frmPost : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _post = new ApiService("post");
        public frmPost()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var requestKorisnik= new KorisniciSearchRequest()
            {
                UserName=ApiService.Username
            };
            var korisnik = await _korisnik.Get<List<Model.Korisnik>>(requestKorisnik);
            var requestPost = new PostUpsertRequest()
            {
                KorisnikId = korisnik[0].KorisnikId,
                Title = txtNaslov1.Text,
                Body = txtNaslov2.Text
            };
            await _post.Insert<Model.Post>(requestPost);
        }

        private async void frmPost_Load(object sender, EventArgs e)
        {
            var requestKorisnik = new KorisniciSearchRequest()
            {
                UserName = ApiService.Username
            };
            var korisnik = await _korisnik.Get<List<Model.Korisnik>>(requestKorisnik);

            var listPost = await _post.Get<List<Model.Post>>(null);

            List<Model.Post> postovi = new List<Model.Post>();

            for (int i = listPost.Count()-1; i>=0 ; i--)
            {
                postovi.Add(listPost[i]);
            }

            dgv_PostHistory.DataSource = postovi;

            dgv_PostHistory.Columns["KorisnikId"].Visible = false; ;
            dgv_PostHistory.Columns["PostId"].Visible = false; ;
            dgv_PostHistory.Columns["Body"].Width = 400; ;
            dgv_PostHistory.Columns["Title"].HeaderText ="Naslov";
            dgv_PostHistory.Columns["Body"].HeaderText = "Sadržaj"; ;

            int brojredova = dgv_PostHistory.Rows.Count;
            int KorisnikID = 0;
            for (int i = 0; i < brojredova; i++)
            {
                KorisnikID = (int)dgv_PostHistory.Rows[i].Cells["KorisnikId"].Value;
                var korisnikO = await _korisnik.GetById<Model.Korisnik>(KorisnikID);

                dgv_PostHistory.Rows[i].Cells["Objavio"].Value = korisnikO.UserName;
            }
        }
    }
}
