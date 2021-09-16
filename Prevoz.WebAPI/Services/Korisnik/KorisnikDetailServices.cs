using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Korisnik;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Prevoz.WebAPI.Services
{
    public class KorisnikDetailServices : IKorisnikDetailService 
    {
        private readonly PrevozContext _context;
        private readonly IMapper _mapper;

        public KorisnikDetailServices(PrevozContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.KorisnikDetails> Get([FromQuery]KorisnikDetailSearchRequest request)
        {
            var query = _context.KorisnikDetails.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Ime))
            {
                query = query.Where(x => x.KorisnikId.Equals(request.KorisnikId));
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.KorisnikDetails>>(list);
        }
        public Model.KorisnikDetails GetById(int Id)
        {
            var entity = _context.KorisnikDetails.Find(Id);

            return _mapper.Map<Model.KorisnikDetails>(entity);
        }

        public Model.KorisnikDetails Insert(KorisnikDetail_UpsertRequest request)
        {
            var entity = _mapper.Map<Database.KorisnikDetails>(request);
            _context.KorisnikDetails.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikDetails>(entity);
        }
        public Model.KorisnikDetails Update(int Id, KorisnikDetail_UpsertRequest request) 
        {
            var entity = _context.KorisnikDetails.Find(Id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikDetails>(entity);
        }
        public Model.KorisnikDetails Delete(int Id)
        {
            var entity = _context.KorisnikDetails.Find(Id);
            _context.KorisnikDetails.Remove(entity);

            return _mapper.Map<Model.KorisnikDetails>(entity);
        }
    }
}
