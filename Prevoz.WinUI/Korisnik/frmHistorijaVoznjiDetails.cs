using GMap.NET;
using GMap.NET.MapProviders;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmHistorijaVoznjiDetails : Form
    {
        ApiService _korisnik = new ApiService("Korisnik");
        ApiService _voznja = new ApiService("voznja");
        ApiService _lokacija = new ApiService("lokacija");
        ApiService _rezervacija = new ApiService("korisnikrezervacija");
        int voznjaId = 0;
        int KorisnikID = -1;
        public frmHistorijaVoznjiDetails(int VoznjaId, int Id)
        {
            InitializeComponent();
            voznjaId = VoznjaId;
            KorisnikID = Id;
        }
        private void SetAdress(string startNaziv, string endNaziv)
        {
            if (startNaziv != "" && startNaziv != null && lbl_Start.Text == "label1")
                lbl_Start.Text = startNaziv;
            
            if (endNaziv!="" && endNaziv != null && lbl_End.Text == "label2")
                lbl_End.Text = endNaziv;
        }
        private double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }

        private Model.KorisnikRezervacija BrojRezervisanih_UkupnoPlaceno_Count_Sum(List<Model.KorisnikRezervacija> list)
        {
            KorisnikRezervacija rezervacija = new KorisnikRezervacija();
            int BrojSjedista = 0;
            decimal UkupnoPlaceno = 0;
            for (int i = 0; i < list.Count; i++)
            {
                 if(list[i].VoznjaId==voznjaId)
                {
                    BrojSjedista += 1;
                    UkupnoPlaceno += list[i].UkupnoPlaceno;
                }
            }
            rezervacija.BrojSjedista = BrojSjedista;
            rezervacija.UkupnoPlaceno = UkupnoPlaceno;
            return rezervacija;
        }
        private async void frmHistorijaVoznjiDetails_Load(object sender, EventArgs e)
        {
            var request = new VoznjaSearchRequest()
            {
                VoznjaId = voznjaId
            };
            var voznja = await _voznja.GetById<Model.Voznja>(voznjaId);

            var rezervacijerequest = new KorisnikRezervacijaSearchRequest()
            {
                KorisnikId = KorisnikID
            };
            var rezervacije = await _rezervacija.Get<List<Model.KorisnikRezervacija>>(rezervacijerequest);

            var korisnik = await _korisnik.GetById<Model.Korisnik>(voznja.KorisnikId);
            var requestStartLocation = await _lokacija.GetById<Model.Lokacija>(voznja.StartId);
            var requestEndLocation = await _lokacija.GetById<Model.Lokacija>(voznja.EndId);

            SetAdress(requestStartLocation.Naziv, requestEndLocation.Naziv);

            string status = "";
            if (voznja.Status == true)
                status = "Aktivno";
            else
                status = "Završeno";

            KorisnikRezervacija result = BrojRezervisanih_UkupnoPlaceno_Count_Sum(rezervacije);

            lbl_UserName.Text = korisnik.UserName;
            lbl_CijenaSjedista.Text = voznja.CijenaSjedista + " KM";
            lbl_BrojRezervisanihSjedista.Text = result.BrojSjedista.ToString();
            lbl_UkupnoKM.Text = result.UkupnoPlaceno + " KM";
            lbl_datumVoznje.Text = voznja.DatumVoznje.ToString();
            lbl_StatusVoznje.Text = status;

            if (voznja.AutomatskoOdobrenje == "DA")
                checkBoxAutomatskoOdobrenje.CheckState = CheckState.Checked;
            else
                checkBoxAutomatskoOdobrenje.CheckState = CheckState.Unchecked;

            if (voznja.Cigarete == "DA")
                checkBoxCigarete.CheckState = CheckState.Checked;
            else
                checkBoxCigarete.CheckState = CheckState.Unchecked;

            if (voznja.KucniLJubimci == "DA")
                checkBoxKucniLjubimci.CheckState = CheckState.Checked;
            else
                checkBoxKucniLjubimci.CheckState = CheckState.Unchecked;


            if (string.IsNullOrWhiteSpace(voznja.Detaljnije))
                labelDetaljiVoznje.Text = "Korisnik nije unio dodatne informacije o vožnji";
            else
                labelDetaljiVoznje.Text = voznja.Detaljnije;

            checkBoxAutomatskoOdobrenje.AutoCheck = false;
            checkBoxCigarete.AutoCheck = false;
            checkBoxKucniLjubimci.AutoCheck = false;

        }
        private void lbl_UserName_Click(object sender, EventArgs e)
        {
            frm_KorisnikInfo frm = new frm_KorisnikInfo(KorisnikID);
            frm.Show();
        }
    }
}
