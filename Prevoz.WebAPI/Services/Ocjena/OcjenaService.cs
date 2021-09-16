using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Ocjena
{
    public class OcjenaService:BaseCRUDService<Model.Ocjena, OcjenaSearchRequest, Database.Vozilo, OcjenaUpsertRequest, OcjenaUpsertRequest>
    {
        public OcjenaService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Ocjena> Get([FromQuery] OcjenaSearchRequest request)
        {
            var query = _context.Ocjena.AsQueryable();

            if (request.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId) || x.VoznjaId==request.VoznjaId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Ocjena>>(list);
        }
        public override Model.Ocjena GetById(int Id)
        {
            var item = _context.Ocjena.Find(Id);

            return _mapper.Map<Model.Ocjena>(item);
        }
        public override Model.Ocjena Insert([FromQuery] OcjenaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Ocjena>(request);

            _context.Ocjena.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjena>(entity);
        }
        public override Model.Ocjena Delete(int Id)
        {
            var entity = _context.Ocjena.Find(Id);
            _context.Ocjena.Remove(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjena>(entity);
        }
    }
}
