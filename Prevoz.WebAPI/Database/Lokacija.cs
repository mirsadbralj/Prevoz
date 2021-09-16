using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            KorisnikDetails = new HashSet<KorisnikDetails>();
            VoznjaEnds = new HashSet<Voznja>();
            VoznjaStarts = new HashSet<Voznja>();
        }

        public int LokacijaId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Naziv { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<KorisnikDetails> KorisnikDetails { get; set; }
        public virtual ICollection<Voznja> VoznjaEnds { get; set; }
        public virtual ICollection<Voznja> VoznjaStarts { get; set; }
    }
}
