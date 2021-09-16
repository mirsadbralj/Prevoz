using Prevoz.Model.Requests.Rezervacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Rezervacija
{
    public interface IKorisnikRezervacijaService
    {
        List<Model.KorisnikRezervacija> Get(KorisnikRezervacijaSearchRequest request);
        Model.KorisnikRezervacija GetById(int Id);
        Model.KorisnikRezervacija Insert(KorisnikRezervacijaUpsertRequest request);
    }
}
