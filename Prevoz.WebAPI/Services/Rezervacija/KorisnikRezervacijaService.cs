using AutoMapper;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Rezervacija
{
    public class KorisnikRezervacijaService : BaseCRUDService<Model.KorisnikRezervacija, KorisnikRezervacijaSearchRequest, Database.KorisnikRezervacija, KorisnikRezervacijaUpsertRequest, KorisnikRezervacijaUpsertRequest>
    {
        public KorisnikRezervacijaService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.KorisnikRezervacija> Get(KorisnikRezervacijaSearchRequest request)
        {
            var query = _context.KorisnikRezervacija.AsQueryable();

            if (request?.KorisnikId > 0)
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.KorisnikRezervacija>>(list);
        }
        public override Model.KorisnikRezervacija GetById(int Id)
        {
            var entity = _context.KorisnikRezervacija.Find(Id);

            return _mapper.Map<Model.KorisnikRezervacija>(entity);
        }

        public override Model.KorisnikRezervacija Insert(KorisnikRezervacijaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.KorisnikRezervacija>(request);

            _context.KorisnikRezervacija.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikRezervacija>(entity);
        }

    }
    
}
