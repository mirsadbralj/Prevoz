using Prevoz.Model.Requests;
using Prevoz.Model.Requests.FAQ;
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
    public partial class frmOdgovorAdd : Form
    {
        ApiService _Faq = new ApiService("faq");
        ApiService _korisnik = new ApiService("korisnik");
        string _pitanje = "";
        int _FaqId = 0;
        public frmOdgovorAdd(string pitanje, int FaqId)
        {
            _pitanje = pitanje;
            _FaqId = FaqId;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var requestkorisnik = new KorisniciSearchRequest()
            {
                UserName= ApiService.Username
            };
            var korisnik = await _korisnik.Get<List<Model.Korisnik>>(requestkorisnik);
            var request = new FaqUpsertRequest()
            {
                KorisnikId = korisnik[0].KorisnikId,
                Pitanje = _pitanje,
                Odgovor = txtOdgovor.Text
            };
            await _Faq.Update<Model.Faq>(_FaqId, request);
        }

        private void frmOdgovorAdd_Load(object sender, EventArgs e)
        {
            lblPitanje.Text = _pitanje;
        }
    }
}
