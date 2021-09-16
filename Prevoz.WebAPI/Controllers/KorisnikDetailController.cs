using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Korisnik;
using Prevoz.Model;
using Microsoft.AspNetCore.Authorization;

namespace Prevoz.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikDetailController : ControllerBase 
    {
        private readonly IKorisnikDetailService _korisnikDetailService;
      
        public KorisnikDetailController(IKorisnikDetailService korisnikDetailService)
        {
            _korisnikDetailService = korisnikDetailService;
        }

        [HttpGet]
        public ActionResult<IList<Model.KorisnikDetails>> Get([FromQuery]KorisnikDetailSearchRequest request)
        {
            return _korisnikDetailService.Get( request);
        }

        [HttpGet("{Id}")]
        public ActionResult<Model.KorisnikDetails> GetById(int Id)
        {
            return _korisnikDetailService.GetById(Id);
        }

        [HttpPost]
        public Model.KorisnikDetails Insert(KorisnikDetail_UpsertRequest request)
        {
            return _korisnikDetailService.Insert(request);
        }

        [HttpPut("{Id}")]
        public Model.KorisnikDetails Update(int Id, KorisnikDetail_UpsertRequest request)
        {
            return _korisnikDetailService.Update(Id, request);
        }
    }
}
