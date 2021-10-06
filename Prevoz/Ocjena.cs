using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Ocjena
    {
        public int OcjenaId { get; set; }
        public int? VoznjaId { get; set; }
        public int KorisnikId { get; set; }
        public int? RezervacijaId { get; set; }
        public int Ocjena1 { get; set; }
        public string Komentar { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
