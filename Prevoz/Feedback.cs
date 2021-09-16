using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int KorisnikId { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
