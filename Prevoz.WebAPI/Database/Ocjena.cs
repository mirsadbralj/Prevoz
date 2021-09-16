using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Ocjena
    {
        public int OcjenaId { get; set; }
        public int? VoznjaId { get; set; }
        public int KorisnikId { get; set; }
        public int? RezervacijaId { get; set; }
        public int Ocjena1 { get; set; }
        public string Komentar { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual KorisnikRezervacija Rezervacija { get; set; }
        public virtual Voznja Voznja { get; set; }
    }
}
