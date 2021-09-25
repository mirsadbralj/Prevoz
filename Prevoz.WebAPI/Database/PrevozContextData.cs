using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prevoz.WebAPI.Database
{
    public partial class PrevozContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().HasData(
                new Korisnik() { KorisnikId = 1, UserName = "admineditor1", PasswordHash = "Hkygp3aJFIgOMtbHckDaXN5HYBA=", PasswordSalt = "DMUTs++b9XRsy8TQxXWtzw==", Slika = null, CreatedAt = new DateTime(2021, 2, 1), ModifiedAt = new DateTime(2021, 2, 1) },
                new Korisnik() { KorisnikId = 2, UserName = "Korisnik", PasswordHash = "Hkygp3aJFIgOMtbHckDaXN5HYBA=", PasswordSalt = "DMUTs++b9XRsy8TQxXWtzw==", Slika = null, CreatedAt = new DateTime(2021, 2, 1), ModifiedAt = new DateTime(2021, 2, 1) },
                new Korisnik() { KorisnikId = 3, UserName = "Korisnik2", PasswordHash = "Hkygp3aJFIgOMtbHckDaXN5HYBA=", PasswordSalt = "DMUTs++b9XRsy8TQxXWtzw==", Slika = null, CreatedAt = new DateTime(2021, 2, 1), ModifiedAt = new DateTime(2021, 2, 1) },
                new Korisnik() { KorisnikId = 4, UserName = "Korisnik3", PasswordHash = "Hkygp3aJFIgOMtbHckDaXN5HYBA=", PasswordSalt = "DMUTs++b9XRsy8TQxXWtzw==", Slika = null, CreatedAt = new DateTime(2021, 2, 1), ModifiedAt = new DateTime(2021, 2, 1) },
                new Korisnik() { KorisnikId = 5, UserName = "headadministrator1", PasswordHash = "Hkygp3aJFIgOMtbHckDaXN5HYBA=", PasswordSalt = "DMUTs++b9XRsy8TQxXWtzw==", Slika = null, CreatedAt = new DateTime(2021, 2, 1), ModifiedAt = new DateTime(2021, 2, 1) }

                );
            modelBuilder.Entity<Post>().HasData(
                new Post() { PostId = 1, KorisnikId = 1, Title = "Tražiš prevoz", Body = "Ovo može biti tvoje najbolje i najjeftinije putovanje do sada" }
                );
            modelBuilder.Entity<Faq>().HasData(
                new Faq() { KorisnikId = 2, Faqid = 1, Pitanje = "Pitanje br.1", Odgovor = "" },
                new Faq() { KorisnikId = 2, Faqid = 2, Pitanje = "Pitanje br.1", Odgovor = "" },
                new Faq() { KorisnikId = 2, Faqid = 3, Pitanje = "Pitanje br.1", Odgovor = "" },
                new Faq() { KorisnikId = 3, Faqid = 4, Pitanje = "Pitanje br.2", Odgovor = "" },
                new Faq() { KorisnikId = 3, Faqid = 5, Pitanje = "Pitanje br.2", Odgovor = "" },
                new Faq() { KorisnikId = 3, Faqid = 6, Pitanje = "Pitanje br.2", Odgovor = "" }
                );
            modelBuilder.Entity<Vozilo>().HasData(
                new Vozilo { VoziloId = 1, KorisnikId = 1, MarkaVozila = "Volkswagen", Naziv = "Golf 7", Slika = null, Boja = "Bijela" },
                new Vozilo { VoziloId = 2, KorisnikId = 2, MarkaVozila = "BMW", Naziv = "BMW 5", Slika = null, Boja = "Crna" },
                new Vozilo { VoziloId = 3, KorisnikId = 3, MarkaVozila = "Volkswagen", Naziv = "Passat 8", Slika = null, Boja = "Siva" },
                new Vozilo { VoziloId = 4, KorisnikId = 4, MarkaVozila = "Mercedes", Naziv = "Golf 5", Slika = null, Boja = "Crna" },
                new Vozilo { VoziloId = 5, KorisnikId = 5, MarkaVozila = "Audi", Naziv = "Audi A5", Slika = null, Boja = "Crvena" }
                );
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge { UlogaId = 1, Naziv = "admin/editor", Opis = "Permisije nad upravljanjem korisnicima, (Uklanjanje korisnika i dodijeljivanje permisije (admin/editor) nekom od korisnika" },
                new Uloge { UlogaId = 2, Naziv = "korisnik", Opis = "Korisnik funkcionalnosti aplikacije" },
                new Uloge { UlogaId = 3, Naziv = "headadmin", Opis = "Permisije nad upravljanjem korisnicima, (Uklanjanje korisnika i dodijeljivanje permisije (admin/editor) nekom od korisnika, mogućnost uklanjanja (admineditor) korisnika i oduzimanja permisija i dodijeljivanja istih." }
                );
            modelBuilder.Entity<KorisnikUloga>().HasData(
                new KorisnikUloga { KorisnikUlogaId = 1, KorisnikId = 1, UlogaId = 1 },
                new KorisnikUloga { KorisnikUlogaId = 2, KorisnikId = 2, UlogaId = 2 },
                new KorisnikUloga { KorisnikUlogaId = 3, KorisnikId = 3, UlogaId = 2 },
                new KorisnikUloga { KorisnikUlogaId = 4, KorisnikId = 4, UlogaId = 2 },
                new KorisnikUloga { KorisnikUlogaId = 5, KorisnikId = 5, UlogaId = 3 }
                );
            modelBuilder.Entity<Lokacija>().HasData(
                new Lokacija { LokacijaId = 1, Latitude = "", Longitude = "", Naziv = "Mostar", PostalCode = "88000" },
                new Lokacija { LokacijaId = 2, Latitude = "", Longitude = "", Naziv = "Sarajevo", PostalCode = "2231" },
                new Lokacija { LokacijaId = 3, Latitude = "", Longitude = "", Naziv = "Zenica", PostalCode = "1233" },
                new Lokacija { LokacijaId = 4, Latitude = "", Longitude = "", Naziv = "Grude", PostalCode = "213213" },
                new Lokacija { LokacijaId = 5, Latitude = "", Longitude = "", Naziv = "Livno", PostalCode = "1231231" },
                new Lokacija { LokacijaId = 6, Latitude = "", Longitude = "", Naziv = "Tuzla", PostalCode = "795986" },
                new Lokacija { LokacijaId = 7, Latitude = "", Longitude = "", Naziv = "Bihać", PostalCode = "84584" },
                new Lokacija { LokacijaId = 8, Latitude = "", Longitude = "", Naziv = "Banja Luka", PostalCode = "548486" },
                new Lokacija { LokacijaId = 9, Latitude = "", Longitude = "", Naziv = "Čapljina", PostalCode = "846846" },
                new Lokacija { LokacijaId = 10, Latitude = "", Longitude = "", Naziv = "Visoko", PostalCode = "468484" }
                );
            modelBuilder.Entity<KorisnikDetails>().HasData(
                new KorisnikDetails { KorisnikId = 1, Ime = "headadmin", Prezime = "headadmin", DatumRođenja = new DateTime(1990, 5, 10), Email = "headadmin@edu.fit.ba", Lokacija = 1, Telefon = "124578324" },
                new KorisnikDetails { KorisnikId = 2, Ime = "Korisnik", Prezime = "Korisnik", DatumRođenja = new DateTime(1993, 1, 10), Email = "korisnik@gmail.com", Lokacija = 2, Telefon = "521353795" },
                new KorisnikDetails { KorisnikId = 3, Ime = "user3", Prezime = "user3", DatumRođenja = new DateTime(1999, 2, 2), Email = "user3@gmail.com", Lokacija = 3, Telefon = "945124906" },
                new KorisnikDetails { KorisnikId = 4, Ime = "user4", Prezime = "user4", DatumRođenja = new DateTime(1992, 1, 6), Email = "user4@gmail.com", Lokacija = 4, Telefon = "4745476" },
                new KorisnikDetails { KorisnikId = 5, Ime = "admineditor", Prezime = "admineditor", DatumRođenja = new DateTime(2000, 2, 1), Email = "admineditor@edu.fit.ba", Lokacija = 2, Telefon = "246790212" }
                );
            modelBuilder.Entity<Voznja>().HasData(
                new Voznja { VoznjaId = 1, KorisnikId = 2, StartId = 1, EndId = 2, VoziloId = 2, CijenaSjedista = 5, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 25) },
                new Voznja { VoznjaId = 2, KorisnikId = 3, StartId = 1, EndId = 2, VoziloId = 3, CijenaSjedista = 6, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 25) },
                new Voznja { VoznjaId = 3, KorisnikId = 2, StartId = 2, EndId = 2, VoziloId = 2, CijenaSjedista = 7, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 25) },
                new Voznja { VoznjaId = 4, KorisnikId = 3, StartId = 1, EndId = 2, VoziloId = 3, CijenaSjedista = 10, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 26) },
                new Voznja { VoznjaId = 5, KorisnikId = 3, StartId = 1, EndId = 8, VoziloId = 3, CijenaSjedista = 12, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 26) },
                new Voznja { VoznjaId = 6, KorisnikId = 3, StartId = 1, EndId = 8, VoziloId = 3, CijenaSjedista = 15, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 26) },
                new Voznja { VoznjaId = 7, KorisnikId = 4, StartId = 2, EndId = 3, VoziloId = 4, CijenaSjedista = 7, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 27) },
                new Voznja { VoznjaId = 8, KorisnikId = 4, StartId = 2, EndId = 3, VoziloId = 4, CijenaSjedista = 8, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 27) },
                new Voznja { VoznjaId = 9, KorisnikId = 4, StartId = 3, EndId = 4, VoziloId = 4, CijenaSjedista = 11, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 28) },
                new Voznja { VoznjaId = 10, KorisnikId = 2, StartId = 5, EndId = 6, VoziloId = 2, CijenaSjedista = 22, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 28) },
                new Voznja { VoznjaId = 11, KorisnikId = 2, StartId = 5, EndId = 6, VoziloId = 2, CijenaSjedista = 10, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 29) },
                new Voznja { VoznjaId = 12, KorisnikId = 4, StartId = 5, EndId = 9, VoziloId = 3, CijenaSjedista = 6, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 29) },
                new Voznja { VoznjaId = 13, KorisnikId = 4, StartId = 2, EndId = 6, VoziloId = 3, CijenaSjedista = 10, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 27) },
                new Voznja { VoznjaId = 14, KorisnikId = 3, StartId = 1, EndId = 9, VoziloId = 3, CijenaSjedista = 10, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 26) },
                new Voznja { VoznjaId = 15, KorisnikId = 2, StartId = 1, EndId = 2, VoziloId = 2, CijenaSjedista = 5, BrojSjedista = 3, Status = true, DatumVoznje = new DateTime(2021, 9, 29) }
                );
            modelBuilder.Entity<KorisnikRezervacija>().HasData(
                new KorisnikRezervacija { RezervacijaId = 1, BrojSjedista = 1, KorisnikId = 4, VoznjaId = 1, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 22) },
                new KorisnikRezervacija { RezervacijaId = 2, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 2, UkupnoPlaceno = 6, DatumRezervacije = new DateTime(2021, 9, 22) },
                new KorisnikRezervacija { RezervacijaId = 3, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 7, UkupnoPlaceno = 7, DatumRezervacije = new DateTime(2021, 9, 21) },
                new KorisnikRezervacija { RezervacijaId = 4, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 8, UkupnoPlaceno = 8, DatumRezervacije = new DateTime(2021, 9, 17) },
                new KorisnikRezervacija { RezervacijaId = 5, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 9, UkupnoPlaceno = 11, DatumRezervacije = new DateTime(2021, 9, 19) },
                new KorisnikRezervacija { RezervacijaId = 6, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 10, UkupnoPlaceno = 22, DatumRezervacije = new DateTime(2021, 9, 20) },
                new KorisnikRezervacija { RezervacijaId = 7, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 8, UkupnoPlaceno = 8, DatumRezervacije = new DateTime(2021, 9, 22) },
                new KorisnikRezervacija { RezervacijaId = 8, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 9, UkupnoPlaceno = 11, DatumRezervacije = new DateTime(2021, 9, 23) },
                new KorisnikRezervacija { RezervacijaId = 9, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 12, UkupnoPlaceno = 6, DatumRezervacije = new DateTime(2021, 9, 24) },
                new KorisnikRezervacija { RezervacijaId = 10, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 1, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 25) },
                new KorisnikRezervacija { RezervacijaId = 11, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 12, UkupnoPlaceno = 6, DatumRezervacije = new DateTime(2021, 9, 16) },
                new KorisnikRezervacija { RezervacijaId = 12, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 13, UkupnoPlaceno = 10, DatumRezervacije = new DateTime(2021, 9, 16) },
                new KorisnikRezervacija { RezervacijaId = 13, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 1, UkupnoPlaceno = 7, DatumRezervacije = new DateTime(2021, 9, 17) },
                new KorisnikRezervacija { RezervacijaId = 14, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 2, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 19) },
                new KorisnikRezervacija { RezervacijaId = 15, BrojSjedista = 1, KorisnikId = 4, VoznjaId = 15, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 19) },
                new KorisnikRezervacija { RezervacijaId = 16, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 15, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 20) },
                new KorisnikRezervacija { RezervacijaId = 17, BrojSjedista = 1, KorisnikId = 4, VoznjaId = 15, UkupnoPlaceno = 5, DatumRezervacije = new DateTime(2021, 9, 16) },
                new KorisnikRezervacija { RezervacijaId = 18, BrojSjedista = 1, KorisnikId = 3, VoznjaId = 13, UkupnoPlaceno = 7, DatumRezervacije = new DateTime(2021, 9, 17) },
                new KorisnikRezervacija { RezervacijaId = 19, BrojSjedista = 1, KorisnikId = 2, VoznjaId = 4, UkupnoPlaceno = 10, DatumRezervacije = new DateTime(2021, 9, 15) },
                new KorisnikRezervacija { RezervacijaId = 20, BrojSjedista = 1, KorisnikId = 4, VoznjaId = 6, UkupnoPlaceno = 15, DatumRezervacije = new DateTime(2021, 9, 16) }
                );
            modelBuilder.Entity<Ocjena>().HasData(
                new Ocjena { OcjenaId = 1, KorisnikId = 4, VoznjaId = 1, RezervacijaId = null, Ocjena1 = 5, Komentar = "Ugodna vožnja, preporuke." },
                new Ocjena { OcjenaId = 2, KorisnikId = 3, VoznjaId = 1, RezervacijaId = null, Ocjena1 = 5, Komentar = "Preporučujem." },
                new Ocjena { OcjenaId = 3, KorisnikId = 2, VoznjaId = null, RezervacijaId = 10, Ocjena1 = 5, Komentar = "Preporučujem kao saputnika." },
                new Ocjena { OcjenaId = 4, KorisnikId = 3, VoznjaId = null, RezervacijaId = 1, Ocjena1 = 4, Komentar = "Vrlo dobro" },
                new Ocjena { OcjenaId = 5, KorisnikId = 3, VoznjaId = null, RezervacijaId = 14, Ocjena1 = 4, Komentar = "Odlična osoba, dobar saputnik, preporučujem." },
                new Ocjena { OcjenaId = 6, KorisnikId = 4, VoznjaId = 2, RezervacijaId = null, Ocjena1 = 5, Komentar = "Odličan vozač" },
                new Ocjena { OcjenaId = 7, KorisnikId = 2, VoznjaId = 2, RezervacijaId = null, Ocjena1 = 5, Komentar = "Odličan vozač" },
                new Ocjena { OcjenaId = 8, KorisnikId = 2, VoznjaId = 12, RezervacijaId = null, Ocjena1 = 5, Komentar = "Ugodna vožnja" },
                new Ocjena { OcjenaId = 9, KorisnikId = 3, VoznjaId = 12, RezervacijaId = null, Ocjena1 = 3, Komentar = "OK." },
                new Ocjena { OcjenaId = 10, KorisnikId = 3, VoznjaId = 3, RezervacijaId = null, Ocjena1 = 4, Komentar = "OK." },
                new Ocjena { OcjenaId = 11, KorisnikId = 4, VoznjaId = 3, RezervacijaId = null, Ocjena1 = 4, Komentar = "OK." },
                new Ocjena { OcjenaId = 12, KorisnikId = 4, VoznjaId = 4, RezervacijaId = null, Ocjena1 = 5, Komentar = "Super." },
                new Ocjena { OcjenaId = 13, KorisnikId = 2, VoznjaId = 4, RezervacijaId = null, Ocjena1 = 5, Komentar = "Super vožnja." }
                );
            modelBuilder.Entity<Zahtjevi>().HasData(
                new Zahtjevi { ZahtjevId = 1, KorisnikId = 2, VoznjaId = 13, Status = null, Datum = new DateTime(2021, 9, 14) },
                new Zahtjevi { ZahtjevId = 2, KorisnikId = 2, VoznjaId = 7, Status = null, Datum = new DateTime(2021, 9, 15) },
                new Zahtjevi { ZahtjevId = 3, KorisnikId = 2, VoznjaId = 12, Status = null, Datum = DateTime.Now },

                new Zahtjevi { ZahtjevId = 4, KorisnikId = 3, VoznjaId = 5, Status = null, Datum = new DateTime(2021, 9, 14) },
                new Zahtjevi { ZahtjevId = 5, KorisnikId = 2, VoznjaId = 6, Status = null, Datum = new DateTime(2021, 9, 17) },
                new Zahtjevi { ZahtjevId = 6, KorisnikId = 2, VoznjaId = 1, Status = null, Datum = new DateTime(2021, 9, 17) },

                new Zahtjevi { ZahtjevId = 7, KorisnikId = 4, VoznjaId = 10, Status = null, Datum = new DateTime(2021, 9, 18) },
                new Zahtjevi { ZahtjevId = 8, KorisnikId = 4, VoznjaId = 11, Status = null, Datum = new DateTime(2021, 9, 19) },
                new Zahtjevi { ZahtjevId = 9, KorisnikId = 4, VoznjaId = 14, Status = null, Datum = new DateTime(2021, 9, 17) },
                new Zahtjevi { ZahtjevId = 10, KorisnikId = 4, VoznjaId = 15, Status = null, Datum = new DateTime(2021, 9, 16) }
                );
            modelBuilder.Entity<Uplate>().HasData(
                new Uplate { UplateId = 1, KorisnikId = 2, Iznos = 100 });
        }
    }
}
