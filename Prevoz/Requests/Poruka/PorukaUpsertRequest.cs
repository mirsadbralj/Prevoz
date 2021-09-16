using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Poruka
{
    public class PorukaUpsertRequest
    {
        public int PosiljaocID { get; set; }
        public int PrimaocID { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Sadrzaj { get; set; }
    }
}
