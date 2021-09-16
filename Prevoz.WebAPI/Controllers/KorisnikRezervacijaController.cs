using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikRezervacijaController : BaseCRUDController<Model.KorisnikRezervacija,KorisnikRezervacijaSearchRequest,KorisnikRezervacijaUpsertRequest, KorisnikRezervacijaUpsertRequest>
    {
        public KorisnikRezervacijaController(ICRUDService<KorisnikRezervacija, KorisnikRezervacijaSearchRequest, KorisnikRezervacijaUpsertRequest, KorisnikRezervacijaUpsertRequest> service) : base(service)
        {
        }

        //[HttpGet]
        //public List<Model.KorisnikRezervacija> Get()
        //{
        //    return _korisnikRezervacijeService.Get();
        //}

        //[HttpGet("{Id}")]
        //public Model.KorisnikRezervacija GetById(int Id)
        //{
        //    return _korisnikRezervacijeService.GetById(Id);
        //}
        //[HttpPost]
        //public Model.KorisnikRezervacija Insert(KorisnikRezervacijaUpsertRequest request)
        //{
        //    return _korisnikRezervacijeService.Insert(request);
        //}
        //[HttpDelete("{Id}")]
        //public Model.KorisnikRezervacija Delete(int Id)
        //{
        //    return _korisnikRezervacijeService.Delete(Id);
        //}
    }
}
