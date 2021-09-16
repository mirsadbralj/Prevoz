using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Lokacija
{
    public class LokacijaService:BaseCRUDService<Model.Lokacija, LokacijaSearchRequest, Database.Lokacija, LokacijaUpsertRequest, LokacijaUpsertRequest>
    {
        public LokacijaService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Lokacija> Get(LokacijaSearchRequest request)
        {
            var query = _context.Lokacija.AsQueryable();

            if (request.Naziv!="" && request.Naziv!=null)
            {
                query = query.Where(x=> x.Naziv.Equals(request.Naziv));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Lokacija>>(list);
        }
        public override Model.Lokacija GetById(int Id)
        {
            var entity = _context.Lokacija.Find(Id);

            return _mapper.Map<Model.Lokacija>(entity);
        }

        public override Model.Lokacija Insert(LokacijaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Lokacija>(request);

            _context.Lokacija.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Lokacija>(entity);
        }

    }
}
