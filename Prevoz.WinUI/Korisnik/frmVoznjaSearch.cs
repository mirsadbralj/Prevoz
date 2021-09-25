using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Zahtjevi;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmVoznjaSearch : Form
    {
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _korisnikRezervacija = new ApiService("korisnikrezervacija");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly ApiService _zahtjevi = new ApiService("zahtjevi");

        public frmVoznjaSearch()
        {
            InitializeComponent();
        }
        private async void  btnPrikazi_Click(object sender, EventArgs e)
        {
            List<Lokacija> listaStartLokacija = new List<Lokacija>();
            List<Voznja> listaVoznjeFilter = new List<Voznja>();

            if (ValidateChildren()) {
                var StartLocationRequest = new LokacijaSearchRequest()
                {
                    Naziv = txtStartLokacija.Text
                };
                var StartLocation = await _lokacija.Get<List<Model.Lokacija>>(StartLocationRequest);
   
                var EndLocationRequest = new LokacijaSearchRequest()
                {
                    Naziv = txtDestLokacija.Text
                };
                var EndLocation = await _lokacija.Get<List<Model.Lokacija>>(EndLocationRequest);
                List<Voznja> listaVoznji = new List<Voznja>();

                StartLocation = StartLocation.Where(x => x.Naziv.Equals(txtStartLokacija.Text)).ToList();

                listaVoznji = await _voznja.Get<List<Model.Voznja>>(null);
                HashSet<int> diffidsStart = new HashSet<int>(StartLocation.Select(s => s.LokacijaId));
                HashSet<int> diffidsEnd = new HashSet<int>(EndLocation.Select(s => s.LokacijaId));

                var resultantList = listaVoznji.Where(item1 =>
                     StartLocation.Any(item2 => item1.StartId == item2.LokacijaId) &&
                     EndLocation.Any(item3=>item1.EndId==item3.LokacijaId)).ToList();

                resultantList = resultantList.Where(item => item.DatumVoznje.Date == dtpDatumVoznjePicker.Value.Date).ToList();

                var listKD = new List<Model.Korisnik>();

                int Id = 0;
                for (int i = 0; i < resultantList.Count(); i++)
                {
                    Id = resultantList[i].KorisnikId;
                    listKD.Add(await _korisnik.GetById<Model.Korisnik>(Id));
                }

                dgvVoznje.AutoGenerateColumns = false;
                dgvVoznje.DataSource = resultantList;
                dgvVoznje.Columns["Rezervisi"].DisplayIndex = 7;

                for (int i = 0; i < dgvVoznje.Rows.Count; i++)
                {
                    int korisnikID = ((int)dgvVoznje.Rows[i].Cells["KorisnikId"].Value);
                    for (int j = 0; j < listKD.Count; j++)
                    {
                        if (korisnikID == listKD[j].KorisnikId)
                        {
                            dgvVoznje.Rows[i].Cells["userName"].Value = listKD[j].UserName;
                            break;
                        }
                    }
                }
            }
                
        }
        private void btnPonistiLatLng_Click(object sender, EventArgs e)
        {
            txtStartLokacija.Text = "";
            txtDestLokacija.Text = "";
        }
        private void frmVoznjaSearch_Load(object sender, EventArgs e)
        {
            dgvVoznje.Columns[0].Visible = false;
            dgvVoznje.Columns["userName"].DisplayIndex = 0;
            dgvVoznje.Columns["Rezervisi"].DisplayIndex = 6;
        }
        private void dgvVoznje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var entityKorisnik = Memorija.Korisnik;

                int VoznjaId = -1;
                if (e.ColumnIndex == dgvVoznje.Columns["Rezervisi"].Index && e.RowIndex >= 0)
                {
                    if (dgvVoznje.Rows[e.RowIndex].Cells["VoznjaId"].RowIndex == e.RowIndex)
                    {
                        if ((int)dgvVoznje.Rows[e.RowIndex].Cells["BrojSjedista"].Value == 0)
                            throw new Exception("Sva sjedista u vozilu su rezervisana.");

                        VoznjaId = (int)dgvVoznje.Rows[e.RowIndex].Cells["VoznjaId"].Value;
                    }
                        RezervacijaVoznje(VoznjaId);
                }
                else if (e.ColumnIndex == dgvVoznje.Columns["Detalji"].Index && e.RowIndex >= 0)
                {
                    VoznjaId = (int)dgvVoznje.Rows[e.RowIndex].Cells["VoznjaId"].Value;

                    frmVoznjaDetails frm = new frmVoznjaDetails(VoznjaId);
                    frm.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void RezervacijaVoznje(int voznjaId)
        {
            var entityKorisnik = Memorija.Korisnik;
            
            var entityVoznja = await _voznja.GetById<Model.Voznja>(voznjaId);


            if (entityVoznja.AutomatskoOdobrenje == "NE")
            {
                MessageBox.Show("Rezervacija vožnje zahtjeva potvrdu vozača", "Zahtjev je poslan, ukoliko vozač odobri vožnju možete je pronaći u rezervacijama", MessageBoxButtons.OK);
                var zahtjevRequest = new ZahtjeviUpsertRequest()
                {
                    VoznjaID = voznjaId,
                    KorisnikID = Memorija.Korisnik.KorisnikId,
                    Datum = DateTime.Now,
                    Status = null
                };
                await _zahtjevi.Insert<Model.Zahtjevi>(zahtjevRequest);
                this.Close();
            }
            else
            {
                var requestRezervacija = new KorisnikRezervacijaUpsertRequest()
                {
                    KorisnikId = entityKorisnik.KorisnikId,
                    VoznjaId = entityVoznja.VoznjaId,
                    BrojSjedista = +1,
                    UkupnoPlaceno = entityVoznja.CijenaSjedista,
                    DatumRezervacije = DateTime.Now
                };
                await _korisnikRezervacija.Insert<Model.KorisnikRezervacija>(requestRezervacija);
                --entityVoznja.BrojSjedista;
                var UpdateRequestVoznja = new VoznjaUpsertRequest()
                {
                    KorisnikId = entityVoznja.KorisnikId,
                    VoziloId = (int)entityVoznja.VoziloId,
                    BrojSjedista = entityVoznja.BrojSjedista,
                    CijenaSjedista = entityVoznja.CijenaSjedista,
                    DatumVoznje = entityVoznja.DatumVoznje,
                    StartId = entityVoznja.StartId,
                    EndId = entityVoznja.EndId,
                    Status = entityVoznja.Status
                };

                await _voznja.Update<Model.Voznja>(voznjaId, UpdateRequestVoznja);
                MessageBox.Show("Voznja uspjesno rezervisana.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }
        private void txtStartLokacija_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStartLokacija.Text))
            {
                errorProviderVoznjaSearch.SetError(txtStartLokacija, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaSearch.SetError(txtStartLokacija, null);
            }
        }
        private void txtDestLokacija_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestLokacija.Text))
            {
                errorProviderVoznjaSearch.SetError(txtDestLokacija, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaSearch.SetError(txtDestLokacija, null);
            }
        }
        private void dtpDatumVoznjePicker_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDatumVoznjePicker.Value.Date < DateTime.Now.Date)
            {
                errorProviderVoznjaSearch.SetError(dtpDatumVoznjePicker, "Datum neispravan");
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaSearch.SetError(dtpDatumVoznjePicker, null);
            }
        }
    }
}
