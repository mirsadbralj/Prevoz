using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Uloge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Uloge
{
    public interface IKorisnikUlogeService
    {
        public List<Model.KorisnikUloge> Get(KorisnikUlogeSearchRequest request);
        public Model.KorisnikUloge GetById(int Id);
        public Model.KorisnikUloge Insert(KorisnikUlogeUpsertRequest request);
    }
}
