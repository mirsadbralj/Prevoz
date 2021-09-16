using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikUlogeController : BaseCRUDController<Model.KorisnikUloge, KorisnikUlogeSearchRequest, KorisnikUlogeUpsertRequest, KorisnikUlogeUpsertRequest>
    {
        public KorisnikUlogeController(ICRUDService<KorisnikUloge, KorisnikUlogeSearchRequest, KorisnikUlogeUpsertRequest, KorisnikUlogeUpsertRequest> service) : base(service)
        {
        }
    }
}
