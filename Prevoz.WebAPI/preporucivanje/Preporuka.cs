using AutoMapper;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.preporucivanje
{
    public class Preporucivanje
    {
        private readonly double _slicnost;
        private readonly IMapper _mapper;
        private readonly PrevozContext _databaseContext;

        private readonly Dictionary<int, List<Ocjena>> _voznja = new Dictionary<int, List<Ocjena>>();
        public Preporucivanje(PrevozContext database, IMapper mapper, double slicnost)
        {
            _mapper = mapper;
            _databaseContext = database;
            _slicnost = slicnost;
        }
        public List<Model.Voznja> PreporuciVoznje(int voznjaId)
        {
            InicijalizirajOstaleVoznje(voznjaId);

            var ocjene = _databaseContext.Ocjena.Where(x => x.VoznjaId == voznjaId).OrderBy(x => x.KorisnikId).ToList();

            var zajednickeOcjene1 = new List<Ocjena>();
            var zajednickeOcjene2 = new List<Ocjena>();
            var preporuceno = new List<Model.Voznja>();

            foreach (var k in _voznja)
            {
                foreach (var o in ocjene)
                {
                    if (k.Value.Where(x => x.KorisnikId == o.KorisnikId).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(k.Value.Where(x => x.KorisnikId == o.KorisnikId).First());
                    }
                }

                var slicnost = IzracunajSlicnostIzmedjuVoznji(zajednickeOcjene1, zajednickeOcjene2);
                if (slicnost > _slicnost)
                {
                    var entity = _databaseContext.Voznja.Find(k.Key);
                    var mapped = _mapper.Map<Model.Voznja>(entity);

                    preporuceno.Add(mapped);
                }

                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }

            return preporuceno;
        }

        private double IzracunajSlicnostIzmedjuVoznji(List<Ocjena> ocjeneVoznjiLijevo, List<Ocjena> ocjeneVoznjiDesno)
        {
            if (ocjeneVoznjiLijevo.Count != ocjeneVoznjiDesno.Count)
                return 0;

            int brojnik = 0;

            double koeficijentZaOcjene1 = 0;
            double koeficijentZaOcjene2 = 0;

            for (int i = 0; i < ocjeneVoznjiLijevo.Count; i++)
            {
                brojnik += ocjeneVoznjiLijevo[i].Ocjena1 * ocjeneVoznjiDesno[i].Ocjena1;

                koeficijentZaOcjene1 += ocjeneVoznjiLijevo[i].Ocjena1 * ocjeneVoznjiLijevo[i].Ocjena1;
                koeficijentZaOcjene2 += ocjeneVoznjiDesno[i].Ocjena1 * ocjeneVoznjiDesno[i].Ocjena1;
            }

            var nazivnik = Math.Sqrt(koeficijentZaOcjene1) * Math.Sqrt(koeficijentZaOcjene2);

            return nazivnik != 0 ? brojnik / nazivnik : 0;

        }
        private void InicijalizirajOstaleVoznje(int voznjaId)
        {
            var ostaleVoznje = _databaseContext.Voznja.Include(k => k.Ocjenas)
                                                      .Where(x => x.VoznjaId != voznjaId && x.Ocjenas.Any()).ToList();
            var IDs = ostaleVoznje.Select(x => x.VoznjaId).ToList();
            var sveOcjene = _databaseContext.Ocjena.Where(x => x.VoznjaId!=null && IDs.Contains(x.VoznjaId.Value)).ToList();
            foreach (var item in ostaleVoznje)
            {
                var ocjene = sveOcjene.Where(x=>x.VoznjaId == item.VoznjaId).OrderBy(o => o.KorisnikId).ToList();

                _voznja.Add(item.VoznjaId, ocjene);
            }
        }
    }
}
