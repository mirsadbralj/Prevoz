using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Poruka
    {
        public int PorukaId { get; set; }
        public int PosiljaocId { get; set; }
        public int PrimaocId { get; set; }
        public DateTime? DatumVrijeme { get; set; }
        public string Sadrzaj { get; set; }

        public virtual Korisnik Posiljaoc { get; set; }
        public virtual Korisnik Primaoc { get; set; }
    }
}
