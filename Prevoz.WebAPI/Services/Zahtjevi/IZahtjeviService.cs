using Prevoz.Model.Requests.Zahtjevi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Services.Zahtjevi
{
    public interface IZahtjeviService
    {
        List<Model.Zahtjevi> Get(ZahtjeviSearchRequest search);
        Model.Zahtjevi Insert(ZahtjeviUpsertRequest request);
    }
}
