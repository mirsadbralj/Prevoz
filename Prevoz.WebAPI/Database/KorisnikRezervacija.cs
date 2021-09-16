using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class KorisnikRezervacija
    {
        public KorisnikRezervacija()
        {
            Ocjenas = new HashSet<Ocjena>();
        }

        public int RezervacijaId { get; set; }
        public int KorisnikId { get; set; }
        public int VoznjaId { get; set; }
        public int? BrojSjedista { get; set; }
        public decimal? UkupnoPlaceno { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Voznja Voznja { get; set; }
        public virtual ICollection<Ocjena> Ocjenas { get; set; }
    }
}
