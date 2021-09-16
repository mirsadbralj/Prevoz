using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Zahtjevi
    {
        public int ZahtjevId { get; set; }
        public int KorisnikId { get; set; }
        public int VoznjaId { get; set; }
        public string Status { get; set; }
        public DateTime? Datum { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Voznja Voznja { get; set; }
    }
}
