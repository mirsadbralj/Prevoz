using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prevoz.Model.Requests
{
    public class KorisniciSearchRequest
    {
        [MinLength(2)]
        public string UserName { get; set; }
    }
}
