using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Uloge
{
    public class KorisnikUlogeService: BaseCRUDService<Model.KorisnikUloge, KorisnikUlogeSearchRequest, Database.KorisnikUloga, KorisnikUlogeUpsertRequest, KorisnikUlogeUpsertRequest>
    {
        public KorisnikUlogeService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.KorisnikUloge> Get([FromQuery]KorisnikUlogeSearchRequest request)
        {
            var query = _context.KorisnikUloga.AsQueryable();

            if (request?.UlogaId!=0 || request.KorisnikId!=0)
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId) || x.UlogaId==request.UlogaId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.KorisnikUloge>>(list);
        }
        public override Model.KorisnikUloge GetById(int Id)
        {
            var entity = _context.KorisnikUloga.Find(Id);

            return _mapper.Map<Model.KorisnikUloge>(entity);
        }

        public override Model.KorisnikUloge Insert(KorisnikUlogeUpsertRequest request)
        {
            var entity = _mapper.Map<Database.KorisnikUloga>(request);

            _context.KorisnikUloga.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikUloge>(entity);
        }
        public  override Model.KorisnikUloge Update(int Id, KorisnikUlogeUpsertRequest request)
        {
            var korisnik = _context.Korisnik.Find(Id);
            KorisnikUloga entityUloga = _context.KorisnikUloga.Where(x=>x.KorisnikId==Id).First();

            entityUloga.KorisnikId = request.KorisnikId;
            entityUloga.UlogaId = request.UlogaId;

            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikUloge>(entityUloga);
        }

    }
}
