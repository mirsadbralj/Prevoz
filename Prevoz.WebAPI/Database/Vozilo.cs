using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Vozilo
    {
        public Vozilo()
        {
            Voznjas = new HashSet<Voznja>();
        }

        public int VoziloId { get; set; }
        public int KorisnikId { get; set; }
        public string MarkaVozila { get; set; }
        public string Boja { get; set; }
        public byte[] Slika { get; set; }
        public string Naziv { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<Voznja> Voznjas { get; set; }
    }
}
