
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
    public partial class frmVoznjaDetails : Form
    {
        private readonly ApiService _voznja = new ApiService("voznja");
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _lokacija = new ApiService("lokacija");

        int voznjaId = 0;
        public frmVoznjaDetails(int VoznjaId)
        {
            InitializeComponent();
            voznjaId = VoznjaId;
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
        private async void frmVoznjaDetails_Load(object sender, EventArgs e)
        {
            var request = new VoznjaSearchRequest()
            {
                VoznjaId = voznjaId
            };
            var voznja = await _voznja.GetById<Model.Voznja>(voznjaId);

            var korisnik = await _korisnik.GetById<Model.Korisnik>(voznja.KorisnikId);
            var requestStartLocation = await _lokacija.GetById<Model.Lokacija>(voznja.StartId);
            var requestEndLocation = await _lokacija.GetById<Model.Lokacija>(voznja.EndId);

            if (voznja.Status == true)
                lbl_StatusVoznje.Text =  "Aktivno";
            else
                lbl_StatusVoznje.Text = "Završeno";

            lbl_Start.Text = requestStartLocation.Naziv;
            lbl_End.Text = requestEndLocation.Naziv;
            lbl_UserName.Text = korisnik.UserName;
            lbl_CijenaSjedista.Text = voznja.CijenaSjedista + " KM";
            lbl_BrojPreostalihSjedista.Text = voznja.BrojSjedista.ToString();
            lbl_datumVoznje.Text = voznja.DatumVoznje.ToString();


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

        }
    }
}
