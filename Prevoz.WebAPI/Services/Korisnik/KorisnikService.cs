using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prevoz.Model;
using Prevoz.Model.Requests;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly PrevozContext _context;
        private readonly IMapper _mapper;
        public KorisnikService(PrevozContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Korisnik Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnik.FirstOrDefault(x => x.UserName == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);

                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<Model.Korisnik>(user);
                }
            }
            return null;
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);

            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public List<Model.Korisnik> Get([FromQuery]KorisniciSearchRequest request)
        {
            var query = _context.Korisnik.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.UserName))
            {
                query = query.Where(x => x.UserName == request.UserName);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Korisnik>>(list); 
        }
        public Model.Korisnik GetById(int Id)
        {
            var entity = _context.Korisnik.Find(Id);

            return  _mapper.Map<Model.Korisnik>(entity);
        }
        public Model.Korisnik Update(int Id, KorisniciUpsertRequests request)
        {
            var entity = _context.Korisnik.Find(Id);

            entity.UserName = request.UserName;
            if(request.Slika!= null && request.Slika.Length > 0)
            {
                entity.Slika = request.Slika;
            }

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwordi se ne slažu!");
                   
                }
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }
            entity.ModifiedAt = DateTime.Now;
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
        public Model.Korisnik Delete(int id)
        { 
            var entity = _context.Korisnik.Find(id);
            var entityDet = _context.KorisnikDetails.Find(id);

            if (_context.KorisnikDetails.Find(id)!=null)
            _context.KorisnikDetails.Remove(entityDet);
            if (_context.Vozilo.Find(id).KorisnikId == id && _context.Vozilo.Find(id)!=null)
            {
                var entityDrive = _context.Vozilo.Find(id);
                _context.Vozilo.Remove(entityDrive);
            }
            _context.Korisnik.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }
        public Model.Korisnik Insert(KorisniciUpsertRequests requests)
        {
            List<Database.Korisnik> list = _context.Korisnik.ToList();

            for (int i = 0; i < _context.Korisnik.Count(); i++)
            {
                if (requests.UserName == list[i].UserName)
                    throw new Exception("Korisničko ime je zauzeto!");
            }
            var entity = _mapper.Map<Database.Korisnik>(requests);

            if (requests.Password != requests.PasswordConfirmation)
            {
                throw new UserException("Passwordi se ne slažu!");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, requests.Password);

            entity.CreatedAt = DateTime.Now;
            entity.ModifiedAt = DateTime.Now;

            _context.Korisnik.Add(entity);
        
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}
