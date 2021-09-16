using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class KorisnikRezervacija
    {
        public int RezervacijaId { get; set; }
        public int KorisnikId { get; set; }
        public int VoznjaId { get; set; }
        public int KreditnaKarticaId { get; set; }
        public int? BrojSjedista { get; set; }
        public decimal UkupnoPlaceno { get; set; }
        public DateTime DatumRezervacije { get; set; }
    }
}
