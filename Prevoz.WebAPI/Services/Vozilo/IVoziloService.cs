using Microsoft.AspNetCore.Mvc;
using Prevoz.Model;
using Prevoz.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services
{
    public interface IVoziloService
    {
        List<Model.Vozilo> Get();
        Model.Vozilo GetById(int Id);
        Model.Vozilo Insert(VoziloUpsertRequest request);
        Model.Vozilo Delete(int Id);
    }
}
