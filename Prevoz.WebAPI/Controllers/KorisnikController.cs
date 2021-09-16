using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Services;

namespace Prevoz.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase 
    {
        private readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Korisnik> Get([FromQuery]KorisniciSearchRequest search)
        {
            return _service.Get(search);
        }
        [HttpGet("{Id}")]
        public Model.Korisnik GetById(int Id)
        {
            return _service.GetById(Id);
        }
        [AllowAnonymous]
        [HttpPost]
        public Model.Korisnik Insert(KorisniciUpsertRequests requests)
        {
            return _service.Insert(requests);
        }
        [HttpPut("{Id}")]
        public Model.Korisnik Update(int Id, [FromBody] KorisniciUpsertRequests request)
        {
            return _service.Update(Id, request);
        }

        [HttpDelete("{Id}")]
        public Model.Korisnik Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}