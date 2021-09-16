using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Feedback;
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
    public partial class frmLeaveFeedback : Form
    {
        private readonly ApiService _apiService = new ApiService("feedback");
        private readonly ApiService _apiServiceKorisnik = new ApiService("korisnik");
        public frmLeaveFeedback()
        {
            InitializeComponent();
        }
        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                for (int i = 1; i <= 5; i++)
                {
                    comboBoxOcjena.Items.Add(i);
                }
                int ocjena = (int)comboBoxOcjena.SelectedItem;
                var korisnik = Memorija.Korisnik;
                int Id = korisnik.KorisnikId;
                var request = new FeedbackUpsertRequest()
                {
                    KorisnikId = Id,
                    Ocjena = ocjena,
                    Komentar = txtKomentar.Text
                };
                await _apiService.Insert<Model.Feedback>(request);
                MessageBox.Show("Vaš feedback je uspješno poslan. Hvala.");
            }
        }
        private void frmLeaveFeedback_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        private void txtOcjena_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxOcjena.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxOcjena, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBoxOcjena, null);
            }
        }
        private void txtKomentar_Validating(object sender, CancelEventArgs e)
        {
            if (txtKomentar.Text.Length == 0)
            {
                errorProvider1.SetError(txtKomentar, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKomentar, null);
            }
        }
    }
}
