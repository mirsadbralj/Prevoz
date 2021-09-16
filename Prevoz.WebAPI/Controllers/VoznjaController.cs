using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services.Vožnja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoznjaController : BaseCRUDController<Model.Voznja, VoznjaSearchRequest,VoznjaUpsertRequest,VoznjaUpsertRequest>
    {
        private readonly IVoznjaService _voznjaService;

        public VoznjaController(ICRUDService<Voznja, VoznjaSearchRequest, VoznjaUpsertRequest, VoznjaUpsertRequest> service) : base(service)
        {
        }
        [HttpGet("PreporuciVoznje")]
        public List<Model.Voznja> PreporuciVoznje([FromQuery] VoznjaSearchRequest search)
        {
            return (_service as VoznjaService).PreporuciVoznje(search);
        }
    }
}
