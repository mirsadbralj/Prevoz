using Prevoz.WebAPI.Database;
using Prevoz.Model;
using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Prevoz.WebAPI.Services
{
    public interface IKorisnikService
    {
        List<Model.Korisnik> Get(KorisniciSearchRequest request);
        Model.Korisnik GetById(int Id);
        Model.Korisnik Insert(KorisniciUpsertRequests requests);
        Model.Korisnik Update(int Id, KorisniciUpsertRequests request);
        Model.Korisnik Delete(int Id);
        Model.Korisnik Authenticiraj(string username, string pass);
    }
}
