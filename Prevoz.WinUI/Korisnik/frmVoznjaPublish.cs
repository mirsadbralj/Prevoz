using Flurl;
using Flurl.Http;
using Flurl.Util;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using Prevoz.Model;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests;
using Prevoz.WinUI.Admin;
using System.Xml;
using System.Xml.Linq;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmVoznjaPublish : Form
    {
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _korisnici = new ApiService("korisnik");
        private readonly ApiService _vozilo = new ApiService("vozilo");
        private readonly ApiService _lokacija = new ApiService("lokacija");
        private readonly List<GMapMarker> currentMarkers = new List<GMapMarker>();
        private GMapOverlay overlayOne;
        private double lat;
        private double lng;

        private double StartLat;
        private double StartLng;
        private string NazivGradaStart = string.Empty;
        private string PostalCodeStart = string.Empty;
        private double DestLat;
        private double DestLng;
        private string NazivGradaEnd= string.Empty;
        private string PostalCodeEnd = string.Empty;

        public frmVoznjaPublish()
        {
            InitializeComponent();
        }
        private void gmap_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.OpenCycleMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gmap.Position = new PointLatLng(43.3438, 17.8078);
            gmap.ShowCenter = false;
        }
        private void AddMarker(GMapMarker item)
        {
            overlayOne.Markers.Add(item);
            gmap.Overlays.Add(overlayOne);
            currentMarkers.Add(item);
            gmap.Refresh();
        }
        private bool SetAdress(PointLatLng point)
        {
            GeoCoderStatusCode status;
            Placemark plc = (Placemark)GMapProviders.OpenCycleMap.GetPlacemark(point, out status);

            if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plc.CountryName != null)
            {
                if (!string.IsNullOrEmpty(plc.Address) && txtStartLokacija.Text == "")
                {
                    txtStartLokacija.Text = plc.Address;
                    StartLat = lat;
                    StartLng = lng;
                    NazivGradaStart = plc.LocalityName;
                    PostalCodeStart = plc.PostalCodeNumber;
                    return true;
                }
                else if (!string.IsNullOrEmpty(plc.Address) && txtDestLokacija.Text == "")
                {
                    txtDestLokacija.Text = plc.Address;
                    DestLat = lat;
                    DestLng = lng;
                    NazivGradaEnd = plc.LocalityName;
                    PostalCodeEnd = plc.PostalCodeNumber;
                    return true;
                }
            }
            return false;
        }
        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (txtStartLokacija.Text == "" || txtDestLokacija.Text == "")
                {
                    lat = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    lng = gmap.FromLocalToLatLng(e.X, e.Y).Lng;

                    overlayOne = new GMapOverlay("OverlayOne");
                    PointLatLng point = new PointLatLng(lat, lng);

                    GMapMarker item = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);

                    AddMarker(item);

                    if (SetAdress(point) == false)
                        MessageBox.Show("Unijeli ste polaznu lokaciju i destinaciju.", "\nUkoliko želite ponovo izvršiti unos, klik na 'Poništi'.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }
        private async Task LoadListaVozila()
        {
            var requestKorisnik = new KorisniciSearchRequest()
            {
                UserName = ApiService.Username
            };
            var korisnici = Memorija.Korisnik;
            var request = new VoznjaSearchRequest();
            var vozila = await _vozilo.Get<List<Model.Vozilo>>(request);
            var Vozila = new List<Vozilo>();

            for (int i = 0; i < vozila.Count(); i++)
            {
                if (vozila[i].KorisnikId.ToString() == korisnici.KorisnikId.ToString())
                {
                    Vozila.Add(vozila[i]);
                }
            }

            Vozila.Insert(0, new Model.Vozilo());
            comboBoxVoziloPicker.DataSource = Vozila;
            comboBoxVoziloPicker.DisplayMember = "MarkaVozila";
            comboBoxVoziloPicker.ValueMember = "VoziloId";

        }
        private void LoadComboBoxes()
        {
            cmbBrojSlobodnihSjedista.Items.Add(" ");
            cmbBrojSlobodnihSjedista.Items.Add(1);
            cmbBrojSlobodnihSjedista.Items.Add(2);
            cmbBrojSlobodnihSjedista.Items.Add(3);
            cmbBrojSlobodnihSjedista.Items.Add(4);
            cmbBrojSlobodnihSjedista.Items.Add(5);
            cmbBrojSlobodnihSjedista.Items.Add(6);
            cmbBrojSlobodnihSjedista.Items.Add(7);
            cmbBrojSlobodnihSjedista.Items.Add(8);
            cmbBrojSlobodnihSjedista.Items.Add(9);
            cmbBrojSlobodnihSjedista.Items.Add(10);
            cmbBrojSlobodnihSjedista.SelectedIndex = 0;

            cmbCigarete.Items.Add("DA");
            cmbCigarete.Items.Add("NE");

            cmbKucniLjubimci.Items.Add("DA");
            cmbKucniLjubimci.Items.Add("NE");

            cmBAutomatskoOdobrenje.Items.Add("DA");
            cmBAutomatskoOdobrenje.Items.Add("NE");

        }
        private async void frmVoznjaPublish_Load(object sender, EventArgs e)
        {
            await LoadListaVozila();
            LoadComboBoxes();
        }
        private async void btnObjavi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                var LokacijaStart = new LokacijaUpsertRequest()
                {
                    Latitude = StartLat.ToString(),
                    Longitude = StartLng.ToString(),
                    Naziv = NazivGradaStart,
                    PostalCode = PostalCodeStart
                };
                if (StartLat==0 && StartLng==0 && txtStartLokacija.Text != "")
                {
                    LokacijaStart.Naziv = txtStartLokacija.Text;
                }
                var LokacijaEnd = new LokacijaUpsertRequest()
                {
                    Latitude = DestLat.ToString(),
                    Longitude = DestLng.ToString(),
                    Naziv = NazivGradaEnd,
                    PostalCode = PostalCodeEnd
                };
                if (DestLat == 0 && DestLng == 0 && txtDestLokacija.Text != "")
                {
                    LokacijaEnd.Naziv = txtDestLokacija.Text;
                }

                var start = await _lokacija.Insert<Model.Lokacija>(LokacijaStart);
                var end = await _lokacija.Insert<Model.Lokacija>(LokacijaEnd);

                var requestKorisnik = new KorisniciSearchRequest()
                {
                    UserName = ApiService.Username
                };

                var korisnici = await _korisnici.Get<List<Model.Korisnik>>(requestKorisnik);
                var var = korisnici[0].KorisnikId;

                var request = new VoznjaUpsertRequest()
                {
                    KorisnikId = korisnici[0].KorisnikId,
                    StartId = start.LokacijaId,
                    EndId = end.LokacijaId,
                    VoziloId = comboBoxVoziloPicker.SelectedIndex,
                    CijenaSjedista = Convert.ToDecimal(txtCijenaSjedista.Text.ToString()),
                    BrojSjedista = Convert.ToInt32(cmbBrojSlobodnihSjedista.Text),
                    Detaljnije = textBoxDetaljnijeInformacije.Text,
                    AutomatskoOdobrenje = cmBAutomatskoOdobrenje.SelectedItem.ToString(),
                    Cigarete = cmbCigarete.SelectedItem.ToString(),
                    KucniLjubimci = cmbKucniLjubimci.SelectedItem.ToString(),
                    Status = true,
                    DatumVoznje = dtpDatumVoznjePicker.Value
                };
                await _voznja.Insert<Model.Voznja>(request);

                DialogResult dr = MessageBox.Show("Vaša vožnja je objavljena!\nDa li želite ocjeniti kvalitet korištenja aplikacije?",
                        "Mood Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr.Equals(DialogResult.Yes))
                {
                    frmLeaveFeedback frm = new frmLeaveFeedback();
                    frm.Show();
                }
            }
        }
        private void btnPonistiLatLng_Click(object sender, EventArgs e)
        {
            txtStartLokacija.Text = "";         
            txtDestLokacija.Text = "";

            for (int i = 0; i < currentMarkers.Count(); i++)
            {
                currentMarkers[i].Overlay.Markers.Remove(currentMarkers[i]);
            }
        }
        private void btnPonistiSve_Click(object sender, EventArgs e)
        {
            txtStartLokacija.Text = "";
            txtDestLokacija.Text = "";
            txtCijenaSjedista.Text = "";
            comboBoxVoziloPicker.SelectedIndex = 0;
            cmbBrojSlobodnihSjedista.SelectedIndex = 0;
            dtpDatumVoznjePicker.Value = DateTime.Now;
            for (int i = 0; i < currentMarkers.Count(); i++)
            {
                currentMarkers[i].Overlay.Markers.Remove(currentMarkers[i]);
            }
        }
        private void txtStartLokacija_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStartLokacija.Text))
            {
                errorProviderVoznjaPublish.SetError(txtStartLokacija, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(txtStartLokacija, null);
            }
        }

        private void txtDestLokacija_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestLokacija.Text))
            {
                errorProviderVoznjaPublish.SetError(txtDestLokacija, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(txtDestLokacija, null);
            }
        }
        private void txtCijenaSjedista_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijenaSjedista.Text))
            {
                errorProviderVoznjaPublish.SetError(txtCijenaSjedista, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(txtCijenaSjedista, null);
            }
        }

        private void comboBoxVoziloPicker_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxVoziloPicker.Text))
            {
                errorProviderVoznjaPublish.SetError(comboBoxVoziloPicker, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(comboBoxVoziloPicker, null);
            }
        }

        private void cmbBrojSlobodnihSjedista_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBrojSlobodnihSjedista.Text))
            {
                errorProviderVoznjaPublish.SetError(cmbBrojSlobodnihSjedista, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(cmbBrojSlobodnihSjedista, null);
            }
        }

        private void dtpDatumVoznjePicker_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtpDatumVoznjePicker.Value.Date < DateTime.Now.Date)
            {
                errorProviderVoznjaPublish.SetError(dtpDatumVoznjePicker, "Datum neispravan");
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(dtpDatumVoznjePicker, null);
            }
        }

        private void frmVoznjaPublish_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void cmBAutomatskoOdobrenje_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmBAutomatskoOdobrenje.Text)){
                errorProviderVoznjaPublish.SetError(cmBAutomatskoOdobrenje, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(cmBAutomatskoOdobrenje, null);
            }
        }

        private void cmbCigarete_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCigarete.Text))
            {
                errorProviderVoznjaPublish.SetError(cmbCigarete, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(cmbCigarete, null);
            }
        }

        private void cmbKucniLjubimci_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbKucniLjubimci.Text))
            {
                errorProviderVoznjaPublish.SetError(cmbKucniLjubimci, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(cmbKucniLjubimci, null);
            }
        }

        private void txtCijenaSjedista_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
               if (!int.TryParse(txtCijenaSjedista.Text, out i))
            {
                errorProviderVoznjaPublish.SetError(txtCijenaSjedista, "Vrijednost mora biti brojčana!");
            }
            else if (txtCijenaSjedista.Text == " ")
            {
                errorProviderVoznjaPublish.SetError(txtCijenaSjedista, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProviderVoznjaPublish.SetError(cmbKucniLjubimci, null);
            }
        }
    }
}
