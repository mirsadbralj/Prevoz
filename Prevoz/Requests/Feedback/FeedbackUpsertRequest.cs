using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Feedback
{
    public class FeedbackUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
