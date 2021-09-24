using Prevoz.Model;
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

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmFAQ : Form
    {
        private readonly ApiService _apiService = new ApiService("faq");
        private int brojacIStih = 0;
        public frmFAQ()
        {
            InitializeComponent();
        }
        
        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var list = await _apiService.Get<List<Model.Faq>>(null);
                var korisnik = Memorija.Korisnik;

                var insert = new FaqUpsertRequest()
                {
                    KorisnikId = korisnik.KorisnikId,
                    Pitanje = txtPitanje.Text
                };

                for (int i = 0; i < list.Count(); i++)
                {
                    if (insert.Pitanje == list[i].Pitanje)
                    {
                        brojacIStih++;
                    }
                }
                if (brojacIStih >= 4)
                {
                    MessageBox.Show("Hvala na pitanju, odgovor na pitanje možete uskoro potražiti u sekciji (Često postavljena pitanja) \nUkoliko se odgovor još uvijek ne nalazi u sekciji molimo vas za strpljenje.\nHvala!");
                    return;
                }
                if (brojacIStih <= 3)
                {
                    MessageBox.Show("Hvala na pitanju, odgovor na pitanje možete uskoro potražiti u sekciji (Često postavljne pitanja)");
                    await _apiService.Insert<Model.Faq>(insert);
                }
            }
        }
        private async void frmFAQ_Load(object sender, EventArgs e)
        {
            var list = await _apiService.Get<List<Model.Faq>>(null);
            list = list.Where(x => x.Pitanje != null && x.Odgovor != null && x.Odgovor!="").ToList();

            var listpitanja = list.Select(x => x.Pitanje).ToList();

            var listFaqs = list.Select(x => new { x.Pitanje, x.Odgovor }).ToList();

            listFaqs = listFaqs.Distinct().ToList();
            listpitanja = listpitanja.Distinct().ToList();
            dgvFAQ.DataSource = list;
        }

        private void txtPitanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPitanje.Text))
            {
                errorProviderFaq.SetError(txtPitanje, "Polje je obavezno i minimalno 5 karaktera je potrebno unijeti");
                e.Cancel = true;
            }
            else
            {
                errorProviderFaq.SetError(txtPitanje, "");
            }
        }

        private void frmFAQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
