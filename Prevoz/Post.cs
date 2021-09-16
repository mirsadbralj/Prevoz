using System;
using System.Collections.Generic;
using System.Text;

namespace Prevoz.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public int KorisnikId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
