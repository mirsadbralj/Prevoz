using System;
using System.Collections.Generic;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int KorisnikId { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
