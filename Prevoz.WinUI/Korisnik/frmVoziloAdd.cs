using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Vozilo;
using Prevoz.Model.Requests.Vožnja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prevoz.WinUI.Korisnik
{
    public partial class frmVoziloAdd : Form
    {
        private readonly ApiService _korisnik = new ApiService("korisnik");
        private readonly ApiService _vozila = new ApiService("vozilo");
        private readonly ApiService _voznja = new ApiService("voznja");
        
        private byte[] SlikaK = null;
        string imageUrl;
        public frmVoziloAdd()
        {
            InitializeComponent();
        }
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";
            picBoxSLikaProfila.SizeMode = PictureBoxSizeMode.Zoom;

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                imageUrl = fileOpen.FileName;
                picBoxSLikaProfila.Image = Image.FromFile(fileOpen.FileName);
            }
            fileOpen.Dispose();

            SlikaK = converterDemo(picBoxSLikaProfila.Image);
        }
        private void LoadBoje()
        {
            cmB_Boja.Items.Add("");
            cmB_Boja.Items.Add("Bijela");
            cmB_Boja.Items.Add("Crna");
            cmB_Boja.Items.Add("Crvena");
            cmB_Boja.Items.Add("Siva");
            cmB_Boja.Items.Add("Plava");
            cmB_Boja.Items.Add("Smeđa");
            cmB_Boja.Items.Add("Žuta");

            cmB_Boja.SelectedIndex = 0;
        }
        private void LoadMarkeVozila()
        {
            cmB_MarkaVozila.Items.Add(" ");
            cmB_MarkaVozila.Items.Add("Alfa Romeo");
            cmB_MarkaVozila.Items.Add("BMW");
            cmB_MarkaVozila.Items.Add("Citroen");
            cmB_MarkaVozila.Items.Add("Dacia");
            cmB_MarkaVozila.Items.Add("Fiat");
            cmB_MarkaVozila.Items.Add("Ford");
            cmB_MarkaVozila.Items.Add("Honda");
            cmB_MarkaVozila.Items.Add("Hyundai");
            cmB_MarkaVozila.Items.Add("Jeep");
            cmB_MarkaVozila.Items.Add("Kia");
            cmB_MarkaVozila.Items.Add("Land Rover");
            cmB_MarkaVozila.Items.Add("Mazda");
            cmB_MarkaVozila.Items.Add("Mercedes Benz");
            cmB_MarkaVozila.Items.Add("Nissan");
            cmB_MarkaVozila.Items.Add("Opel");
            cmB_MarkaVozila.Items.Add("Peugeot");
            cmB_MarkaVozila.Items.Add("Renault");
            cmB_MarkaVozila.Items.Add("Toyota");
            cmB_MarkaVozila.Items.Add("Volkswagen");

            cmB_MarkaVozila.SelectedIndex = 0;
        }
        private void ClearVoziloAddForm()
        {
            picBoxSLikaProfila.Image = null;
            txtNazvVozila.Text = "";
            cmB_MarkaVozila.SelectedIndex = 0;
            cmB_Boja.SelectedIndex = 0;
        }
        private async void DataGridViewRefreshData()
        {
            var entityKorisnik = Memorija.Korisnik;

            var request = new VoziloSearchRequest()
            {
                KorisnikId = entityKorisnik.KorisnikId
            };

            var list = await _vozila.Get<List<Model.Vozilo>>(request);
            LoadDataIntoDataGrid(list);
            ClearVoziloAddForm();
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var requestK = new KorisniciSearchRequest() { UserName = ApiService.Username };

                var korisnik = await _korisnik.Get<List<Model.Korisnik>>(requestK);

                var id = korisnik[0].KorisnikId;
                SlikaK = converterDemo(picBoxSLikaProfila.Image);

                if (SlikaK != null && SlikaK.Length > 0)
                {
                    var request = new VoziloUpsertRequest()
                    {
                        KorisnikId = id,
                        MarkaVozila = cmB_MarkaVozila.SelectedItem.ToString(),
                        Naziv = txtNazvVozila.Text,
                        Boja = cmB_Boja.SelectedItem.ToString(),
                        Slika = SlikaK
                    };
                    await _vozila.Insert<Model.Vozilo>(request);
                    DataGridViewRefreshData();
                }
                else
                    MessageBox.Show("Slika automobila je obavezna", "", MessageBoxButtons.OK);
            }
        }
        private async void frmVozilo_Load(object sender, EventArgs e)
        {
            LoadBoje();
            LoadMarkeVozila();

            var entityKorisnik =  Memorija.Korisnik;

            var request = new VoziloSearchRequest()
            {
                KorisnikId = entityKorisnik.KorisnikId 
            };

            var list = await _vozila.Get<List<Model.Vozilo>>(request);

            LoadDataIntoDataGrid(list);
        }

        public void LoadDataIntoDataGrid(List<Vozilo> listavozila)
        { 
            foreach(var item in listavozila)
            {
                if (item.Slika.Length == 0)
                    item.Slika = null;
            }
            dgv_ListaVozila.DataSource = listavozila;
            dgv_ListaVozila.Columns["Ukloni"].DisplayIndex = 6;

            DataGridViewImageColumn columnimg = (DataGridViewImageColumn)dgv_ListaVozila.Columns[6];
            columnimg.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewTextBoxColumn columnimgVoziloId = (DataGridViewTextBoxColumn)dgv_ListaVozila.Columns[1];
            columnimgVoziloId.Visible = false;

            DataGridViewTextBoxColumn columnimgKorisnikId = (DataGridViewTextBoxColumn)dgv_ListaVozila.Columns[2];
            columnimgKorisnikId.Visible = false;
        }
        private async void dgv_ListaVozila_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dgv_ListaVozila.Columns["Ukloni"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ukloniti vozilo?", "\n", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult==DialogResult.Yes)
                {
                    string Vozilo = dgv_ListaVozila.Rows[e.RowIndex].Cells["VoziloId"].Value.ToString();
                    int VoziloId = Int32.Parse(Vozilo);
                    var listVoznje = await _voznja.Get<List<Model.Voznja>>(null);

                    List<Voznja> voznje = new List<Voznja>();

                    foreach(var item in listVoznje)
                    {
                        if (item.VoziloId == VoziloId)
                            voznje.Add(item);
                    }

                    for (int i = 0; i < voznje.Count(); i++)
                    {
                        voznje[i].VoziloId = null;
                        var request = new VoznjaUpsertRequest()
                        {
                            KorisnikId = voznje[i].KorisnikId,
                            DatumVoznje = voznje[i].DatumVoznje,
                            BrojSjedista = voznje[i].BrojSjedista,
                            CijenaSjedista = voznje[i].CijenaSjedista,
                            StartId = voznje[i].StartId,
                            EndId = voznje[i].EndId,
                            Status = voznje[i].Status,
                            VoziloId = voznje[i].VoziloId
                        };
                        await _voznja.Update<Model.Voznja>(voznje[i].VoznjaId, request);
                    }
                    await _vozila.Delete<Model.Vozilo>(VoziloId);
                }
            }
        }
  
        private void cmB_MarkaVozila_Validating(object sender, CancelEventArgs e)
        {
            if(cmB_MarkaVozila.Text == " ")
            {
                errorProvider1.SetError(cmB_MarkaVozila, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmB_MarkaVozila, null);
            }
        }
        private void txtNazvVozila_Validating(object sender, CancelEventArgs e)
            {
            if (txtNazvVozila.Text.Length == 0)
            {
                errorProvider1.SetError(txtNazvVozila, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNazvVozila, null);
            }
        }
        private void cmB_Boja_Validating(object sender, CancelEventArgs e)
        {
            if (cmB_Boja.Text == "")
            {
                errorProvider1.SetError(cmB_Boja, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmB_Boja, null);
            }
        }
    }
}
