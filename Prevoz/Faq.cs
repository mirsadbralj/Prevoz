using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Faq
    {
        public int FaqId { get; set; }
        public int KorisnikId { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
    }
}
