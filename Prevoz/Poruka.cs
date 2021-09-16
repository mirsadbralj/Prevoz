using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Poruka
    {
        public int PorukaID { get; set; }
        public int PosiljaocID { get; set; }
        public int PrimaocID { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Sadrzaj { get; set; }
        public bool JaPosiljaoc { get; set; }
        public bool JaNisamPosiljaoc => !JaPosiljaoc;
    }
}
