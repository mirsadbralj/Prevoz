using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Zahtjevi
    {
        public int ZahtjevID { get; set; }
        public int KorisnikID { get; set; }
        public int VoznjaID { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }
    }
}
