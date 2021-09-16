using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Vozilo;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloController : BaseCRUDController<Model.Vozilo, VoziloSearchRequest,VoziloUpsertRequest, VoziloUpsertRequest>
    {
        public VoziloController(ICRUDService<Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest> service) : base(service)
        {
        }

    }
}
