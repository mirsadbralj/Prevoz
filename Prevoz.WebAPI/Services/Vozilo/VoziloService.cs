using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Vozilo;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services
{
    public class VoziloService : BaseCRUDService<Model.Vozilo, VoziloSearchRequest, Database.Vozilo, VoziloUpsertRequest, VoziloUpsertRequest>
    {
        public VoziloService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Vozilo> Get([FromQuery]VoziloSearchRequest request)
        {
            var query = _context.Vozilo.AsQueryable();

            if (request.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Vozilo>>(list);
        }
        public override Model.Vozilo GetById(int Id)
        {
                var item = _context.Vozilo.Find(Id);

                return _mapper.Map<Model.Vozilo>(item);
        }
        public override Model.Vozilo Insert(VoziloUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Vozilo>(request);

            _context.Vozilo.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Vozilo>(entity);
        }
        public override Model.Vozilo Delete(int Id)
        { 
            var entity = _context.Vozilo.Find(Id);
            _context.Vozilo.Remove(entity); 
            _context.SaveChanges();

                return _mapper.Map<Model.Vozilo>(entity);         
        }
    }
}
