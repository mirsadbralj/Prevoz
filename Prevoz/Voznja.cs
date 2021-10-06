using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Voznja
    {
        public int VoznjaId { get; set; }
        public int KorisnikId { get; set; }
        public int StartId { get; set; }
        public int EndId { get; set; }
        public int? VoziloId { get; set; }
        public decimal CijenaSjedista { get; set; }
        public int? BrojSjedista { get; set; }
        public bool? Status { get; set; }
        public string AutomatskoOdobrenje { get; set; }
        public string Cigarete { get; set; }
        public string KucniLJubimci { get; set; }
        public string Detaljnije { get; set; }
        public DateTime DatumVoznje { get; set; }
        public string PolaznaLokacija { get; set; }
        public string Destinacija { get; set; }
    }
}
