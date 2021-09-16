using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Uplate
    {
        public int UplateId { get; set; }
        public int KorisnikId { get; set; }
        public decimal? Iznos { get; set; }
        public DateTime? DatumUplate { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
