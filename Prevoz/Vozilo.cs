using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Vozilo
    {
        public int VoziloId { get; set; }
        public int KorisnikId { get; set; }
        public string MarkaVozila { get; set; }
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public byte[] Slika { get; set; }
    }
}
