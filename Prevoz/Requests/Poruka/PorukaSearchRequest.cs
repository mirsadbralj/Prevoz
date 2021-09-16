using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model.Requests.Poruka
{
    public class PorukaSearchRequest
    {
        public int PosiljaocID { get; set; }
        public int PrimaocID { get; set; }
        public DateTime DatumVrijeme { get; set; }
    }
}
