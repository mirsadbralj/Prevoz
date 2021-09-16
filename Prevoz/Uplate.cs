using System;

namespace Prevoz.Model
{
    public class Uplate
    {
        public int UplataId { get; set; }

        public int KorisnikId { get; set; }

        public decimal Iznos { get; set; }

        public DateTime DatumUplate { get; set; }
    }
}