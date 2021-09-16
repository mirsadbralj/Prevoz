using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class KorisnikDetails
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? Lokacija { get; set; }
        public string Telefon { get; set; }
        public DateTime? DatumRođenja { get; set; }
        public string Email { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Lokacija LokacijaNavigation { get; set; }
    }
}
