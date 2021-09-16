using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests.Post
{
    public class PostUpsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
