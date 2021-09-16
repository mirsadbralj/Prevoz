using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Voznja
    {
        public Voznja()
        {
            KorisnikRezervacijas = new HashSet<KorisnikRezervacija>();
            Ocjenas = new HashSet<Ocjena>();
            Zahtjevis = new HashSet<Zahtjevi>();
        }

        public int VoznjaId { get; set; }
        public int KorisnikId { get; set; }
        public int StartId { get; set; }
        public int EndId { get; set; }
        public int? VoziloId { get; set; }
        public decimal? CijenaSjedista { get; set; }
        public int? BrojSjedista { get; set; }
        public bool? Status { get; set; }
        public DateTime DatumVoznje { get; set; }
        public string AutomatskoOdobrenje { get; set; }
        public string Cigarete { get; set; }
        public string KucniLjubimci { get; set; }
        public string Detaljnije { get; set; }

        public virtual Lokacija End { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Lokacija Start { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual ICollection<KorisnikRezervacija> KorisnikRezervacijas { get; set; }
        public virtual ICollection<Ocjena> Ocjenas { get; set; }
        public virtual ICollection<Zahtjevi> Zahtjevis { get; set; }
    }
}
