using AutoMapper;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.FAQ;
using Prevoz.Model.Requests.Feedback;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.Model.Requests.Poruka;
using Prevoz.Model.Requests.Post;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Uloge;
using Prevoz.Model.Requests.Uplate;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.Model.Requests.Zahtjevi;
using Prevoz.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, KorisniciUpsertRequests>().ReverseMap();
            CreateMap<Database.Korisnik, KorisniciUpsertRequests>().ReverseMap();

            CreateMap<Database.KorisnikDetails, Model.KorisnikDetails>();
            CreateMap<Database.KorisnikDetails, KorisnikDetail_UpsertRequest>().ReverseMap();
            CreateMap<Model.KorisnikDetails, KorisnikDetail_UpsertRequest>().ReverseMap();

            CreateMap<Database.Vozilo, Model.Vozilo>();
            CreateMap<Model.Vozilo, VoziloUpsertRequest>().ReverseMap();
            CreateMap<Database.Vozilo, VoziloUpsertRequest>().ReverseMap();

            CreateMap<Database.Feedback, Model.Feedback>();
            CreateMap<Database.Feedback, FeedbackUpsertRequest>().ReverseMap();

            CreateMap<Database.Faq, Model.Faq>();
            CreateMap<Model.Faq, FaqUpsertRequest>().ReverseMap();
            CreateMap<Database.Faq, FaqUpsertRequest>().ReverseMap();


            CreateMap<Database.KorisnikRezervacija, Model.KorisnikRezervacija>();
            CreateMap<Database.KorisnikRezervacija, KorisnikRezervacijaUpsertRequest>().ReverseMap();
            CreateMap<Model.KorisnikRezervacija, KorisnikRezervacijaUpsertRequest>().ReverseMap();


            CreateMap<Database.Lokacija, Model.Lokacija>();
            CreateMap<Database.Lokacija, LokacijaUpsertRequest>().ReverseMap();
            CreateMap<Model.Lokacija, LokacijaUpsertRequest>().ReverseMap();
            CreateMap<Model.Lokacija, LokacijaSearchRequest>().ReverseMap();


            CreateMap<Database.Voznja, Model.Voznja>();
            CreateMap<Database.Voznja, VoznjaUpsertRequest>().ReverseMap();
            CreateMap<Database.Voznja, VoznjaSearchRequest>().ReverseMap();
            CreateMap<Model.Voznja, VoznjaSearchRequest>().ReverseMap();

            CreateMap<Database.Post, Model.Post>();
            CreateMap<Database.Post, PostUpsertRequest>().ReverseMap();

            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<Database.Ocjena, OcjenaUpsertRequest>().ReverseMap();
            CreateMap<Model.Ocjena, OcjenaUpsertRequest>().ReverseMap();
            CreateMap<Model.Ocjena, OcjenaSearchRequest>().ReverseMap();


            CreateMap<Database.Uloge, Model.Uloge>();
            CreateMap<Database.Uloge, UlogeUpsertRequest>().ReverseMap();
            CreateMap<Model.Uloge, UlogeUpsertRequest>().ReverseMap();
            CreateMap<Model.Uloge, UlogeSearchRequest>().ReverseMap();

            CreateMap<Database.KorisnikUloga, Model.KorisnikUloge>();
            CreateMap<Database.KorisnikUloga, KorisnikUlogeUpsertRequest>().ReverseMap();
            CreateMap<Model.KorisnikUloge, KorisnikUlogeUpsertRequest>().ReverseMap();
            CreateMap<Model.KorisnikUloge, KorisnikUlogeSearchRequest>().ReverseMap();

            CreateMap<Database.Poruka, Model.Poruka>();
            CreateMap<Database.Poruka, PorukaUpsertRequest>().ReverseMap();
            CreateMap<Model.Poruka, PorukaSearchRequest>().ReverseMap();
            CreateMap<Model.Poruka, PorukaUpsertRequest>().ReverseMap();

            CreateMap<Database.Uplate, Model.Uplate>();
            CreateMap<Database.Uplate, UplateUpsertRequest>().ReverseMap();
            CreateMap<Model.Uplate, UplateSearchRequest>().ReverseMap();
            CreateMap<Model.Uplate, UplateSearchRequest>().ReverseMap();

            CreateMap<Database.Zahtjevi, Model.Zahtjevi>();
            CreateMap<Database.Zahtjevi, ZahtjeviUpsertRequest>().ReverseMap();
            CreateMap<Model.Zahtjevi, ZahtjeviSearchRequest>().ReverseMap();
            CreateMap<Model.Zahtjevi, ZahtjeviSearchRequest>().ReverseMap();
        }
    }
}
