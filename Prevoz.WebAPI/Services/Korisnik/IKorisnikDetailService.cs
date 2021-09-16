using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services
{
    public interface IKorisnikDetailService
    {
        List<Model.KorisnikDetails> Get(KorisnikDetailSearchRequest request);
        Model.KorisnikDetails GetById(int Id);
        Model.KorisnikDetails Insert(KorisnikDetail_UpsertRequest request);
        Model.KorisnikDetails Update(int Id, KorisnikDetail_UpsertRequest request);
        Model.KorisnikDetails Delete(int Id);
    }
}
