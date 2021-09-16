using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frm_KorisnikInfo : Form
    {

        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _rezervacije = new ApiService("korisnikrezervacija");
        private readonly ApiService _korisnikDetails = new ApiService("korisnikdetail");
        private readonly ApiService _ocjene = new ApiService("ocjena");
        private readonly ApiService _voznje = new ApiService("voznja");

        List<Model.Ocjena> Lista_Ocjena = new List<Model.Ocjena>();

        int _KorisnikID = 0;
        public frm_KorisnikInfo(int KorisnikID)
        {
            _KorisnikID = KorisnikID;
            InitializeComponent();
        }
        private async void GetKorisnikOcjene(List<Model.Ocjena> ocjene)
        {
            List<Model.Ocjena> _listaOcjena = new List<Model.Ocjena>();
            List<Model.Voznja> _listaVoznji = new List<Model.Voznja>();
            List<Model.KorisnikRezervacija> _listaRezervacija = new List<Model.KorisnikRezervacija>();

            var listaRezervacija = await _rezervacije.Get<List<Model.KorisnikRezervacija>>(null);
            var listaVoznji = await _voznje.Get<List<Model.Voznja>>(null);

            for (int i = 0; i < listaRezervacija.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].RezervacijaId == listaRezervacija[i].RezervacijaId && listaRezervacija[i].KorisnikId == _KorisnikID)
                    {
                        _listaOcjena.Add(ocjene[j]);
                        _listaRezervacija.Add(listaRezervacija[i]);
                    }
                }
            }
            for (int i = 0; i < listaVoznji.Count(); i++)
            {
                for (int j = 0; j < ocjene.Count(); j++)
                {
                    if (ocjene[j].VoznjaId == listaVoznji[i].VoznjaId && listaVoznji[i].KorisnikId == _KorisnikID)
                    {
                        _listaVoznji.Add(listaVoznji[i]);
                        _listaOcjena.Add(ocjene[j]);
                    }
                }
            }
            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 2;
            decimal ocjena;
            if (_listaOcjena.Count() > 0)
                ocjena = GetProsjek(_listaOcjena);
            else
                ocjena = 0;
            lblProsjecnaOcjena.Text = ocjena.ToString();
            dgvKorisnikOcjene.DataSource = _listaOcjena;
        }
        private decimal GetProsjek(List<Model.Ocjena> ocjene)
        {
            decimal suma = 0;
            decimal prosjek = 0;
            int brojac = 0;

            for (int i = 0; i < ocjene.Count(); i++)
            {
                suma += (decimal)ocjene[i].Ocjena1;
                brojac++;
            }
            prosjek = suma / brojac;
            return prosjek;
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private async void frm_KorisnikInfo_Load(object sender, EventArgs e)
        {
            if (_KorisnikID > 0)
            {
                var korisnik = await _korisnik.GetById<Model.Korisnik>(_KorisnikID);
                var korisnikDetails = await _korisnikDetails.GetById<Model.KorisnikDetails>(_KorisnikID);
                var ocjene = await _ocjene.Get<List<Model.Ocjena>>(null);

                if (korisnikDetails != null) 
                {
                    lblIme.Text = korisnikDetails.Ime;
                    lblprezime.Text = korisnikDetails.Prezime;
                    lblDatumRodjenja.Text = korisnikDetails.DatumRođenja.ToString();
                }
                else
                {
                    lblIme.Text = " ";
                    lblprezime.Text = " ";
                    lblDatumRodjenja.Text = " ";
                }
                lblKorisnickoIme.Text = korisnik.UserName;
               
                lblDatumKreiranja.Text = korisnik.CreatedAt.ToString();

                picBoxSLikaProfila.SizeMode = PictureBoxSizeMode.Zoom;
                if (korisnik.Slika.Length > 0)
                    picBoxSLikaProfila.Image = ByteToImage(korisnik.Slika);
                else
                    picBoxSLikaProfila.Image = null;
                GetKorisnikOcjene(ocjene);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPosaljiPoruku frm = new frmPosaljiPoruku(_KorisnikID);
            frm.Show();
        }
    }
}
