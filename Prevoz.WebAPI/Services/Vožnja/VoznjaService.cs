using AutoMapper;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.preporucivanje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Vožnja
{
    public class VoznjaService:BaseCRUDService<Model.Voznja, VoznjaSearchRequest, Database.Voznja, VoznjaUpsertRequest, VoznjaUpsertRequest>
    {
        private readonly Preporucivanje _preporucivanje;
        public VoznjaService(PrevozContext context, IMapper mapper) : base(context, mapper)
        {
            _preporucivanje = new Preporucivanje(context, mapper, 0.6);
        }
        public override List<Model.Voznja> Get(VoznjaSearchRequest request)
        {
            var query = _context.Voznja.AsQueryable();
            var queryLok = _context.Lokacija.AsQueryable();
            if (request!=null &&(request.DatumVoznje.Date != DateTime.MinValue.Date || (request.StartId != null && request.EndId != null)))
            {
                query = query.Where(x => x.DatumVoznje.Date.Equals(request.DatumVoznje.Date)
                                  && (x.StartId == request.StartId && x.EndId == request.EndId)); 
            }
            else if(request != null && (request.StartId == null && request.EndId == null && request.KorisnikId > 0 && request.VoznjaId == 0))
            {
                query = query.Where(x => x.KorisnikId == request.KorisnikId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Voznja>>(list);
        }
        public override Model.Voznja GetById(int Id)
        {
                var entity = _context.Voznja.Find(Id);
                return _mapper.Map<Model.Voznja>(entity);
        }
        public Model.Voznja FilterByStartId(int Id)
        {
            var entity = _context.Voznja.Find(Id);

            if (entity.StartId == Id)
                return _mapper.Map<Model.Voznja>(entity);
            else
            return null;
        }
        public override Model.Voznja Insert(VoznjaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Voznja>(request);
            
            _context.Voznja.Add(entity);
           
            _context.SaveChanges();

            return _mapper.Map<Model.Voznja>(entity);
        }
        public List<Model.Voznja> PreporuciVoznje(VoznjaSearchRequest search)
        {
            return _preporucivanje.PreporuciVoznje(search.VoznjaId);
        }
    }
}
