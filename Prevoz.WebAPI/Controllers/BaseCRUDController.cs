using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        public T Insert(TInsert requests)
        {
            return _service.Insert(requests);
        }
        [HttpPut("{Id}")]
        public T Update(int Id,[FromBody] TUpdate request)
        {
            return _service.Update(Id, request);
        }
        [HttpDelete("{Id}")]
        public T Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
