using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests.Uplate;
using Prevoz.WebAPI.Database;
using Stripe;
using System.Collections.Generic;
using System.Linq;

namespace Prevoz.WebAPI.Services
{
    public class UplateService : BaseCRUDService<Model.Uplate, UplateSearchRequest, Database.Uplate, UplateUpsertRequest, UplateUpsertRequest>
    {
        public UplateService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Uplate> Get([FromQuery] UplateSearchRequest request)
        {
            var query = _context.Uplate.AsQueryable();

            if (request.KorisnikId > 0)
            {
                query = query.Where(x => x.KorisnikId == request.KorisnikId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Uplate>>(list);
        }
        public override Model.Uplate GetById(int Id)
        {
            var entity = _context.Korisnik.Find(Id);
            return _mapper.Map<Model.Uplate>(entity);
        }
        public override Model.Uplate Insert(UplateUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Uplate>(request);

            _context.Uplate.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Uplate>(entity);
        }
    }
}