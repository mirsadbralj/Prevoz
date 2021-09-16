using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Faq
    {
        public int Faqid { get; set; }
        public int KorisnikId { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
