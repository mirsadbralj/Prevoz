using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prevoz.WebAPI.Database
{
    public partial class PrevozContext : DbContext
    {
        public PrevozContext()
        {
        }

        public PrevozContext(DbContextOptions<PrevozContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikDetails> KorisnikDetails { get; set; }
        public virtual DbSet<KorisnikRezervacija> KorisnikRezervacija { get; set; }
        public virtual DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Poruka> Poruka { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<Uplate> Uplate { get; set; }
        public virtual DbSet<Vozilo> Vozilo { get; set; }
        public virtual DbSet<Voznja> Voznja { get; set; }
        public virtual DbSet<Zahtjevi> Zahtjevi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Prevoz;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Faqid).HasColumnName("FAQID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Odgovor).HasMaxLength(500);

                entity.Property(e => e.Pitanje).HasMaxLength(500);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Faqs)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAQ__KorisnikID__2B3F6F97");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.Komentar).HasMaxLength(400);

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Korisn__4CA06362");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("ModifiedAT");

                entity.Property(e => e.PasswordHash).HasColumnType("text");

                entity.Property(e => e.PasswordSalt).HasColumnType("text");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CS_AS");
            });

            modelBuilder.Entity<KorisnikDetails>(entity =>
            {
                entity.HasKey(e => e.KorisnikId)
                    .HasName("PK__Korisnik__80B06D614EBF07A9");

                entity.Property(e => e.KorisnikId)
                    .ValueGeneratedNever()
                    .HasColumnName("KorisnikID");

                entity.Property(e => e.DatumRođenja).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.KorisnikDetail)
                    .HasForeignKey<KorisnikDetails>(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikD__Koris__48CFD27E");

                entity.HasOne(d => d.LokacijaNavigation)
                    .WithMany(p => p.KorisnikDetails)
                    .HasForeignKey(d => d.Lokacija)
                    .HasConstraintName("FK__KorisnikD__Lokac__49C3F6B7");
            });

            modelBuilder.Entity<KorisnikRezervacija>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId)
                    .HasName("PK__Korisnik__CABA44FDD8B8A748");

                entity.ToTable("KorisnikRezervacija");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.DatumRezervacije).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UkupnoPlaceno).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VoznjaId).HasColumnName("VoznjaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisnikRezervacijas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikR__Koris__3F466844");

                entity.HasOne(d => d.Voznja)
                    .WithMany(p => p.KorisnikRezervacijas)
                    .HasForeignKey(d => d.VoznjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikR__Voznj__403A8C7D");
            });

            modelBuilder.Entity<KorisnikUloga>(entity =>
            {
                entity.ToTable("KorisnikUloga");

                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisnikUlogas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Koris__35BCFE0A");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisnikUlogas)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Uloga__36B12243");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("Lokacija");

                entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");

                entity.Property(e => e.Latitude).HasMaxLength(20);

                entity.Property(e => e.Longitude).HasMaxLength(20);

                entity.Property(e => e.Naziv).HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(20);
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.ToTable("Ocjena");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.Komentar).HasMaxLength(300);

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Ocjena1).HasColumnName("Ocjena");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.VoznjaId).HasColumnName("VoznjaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ocjenas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ocjena__Korisnik__44FF419A");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Ocjenas)
                    .HasForeignKey(d => d.RezervacijaId)
                    .HasConstraintName("FK__Ocjena__Rezervac__45F365D3");

                entity.HasOne(d => d.Voznja)
                    .WithMany(p => p.Ocjenas)
                    .HasForeignKey(d => d.VoznjaId)
                    .HasConstraintName("FK__Ocjena__VoznjaID__440B1D61");
            });

            modelBuilder.Entity<Poruka>(entity =>
            {
                entity.ToTable("Poruka");

                entity.Property(e => e.PorukaId).HasColumnName("PorukaID");

                entity.Property(e => e.DatumVrijeme).HasColumnType("datetime");

                entity.Property(e => e.PosiljaocId).HasColumnName("PosiljaocID");

                entity.Property(e => e.PrimaocId).HasColumnName("PrimaocID");

                entity.HasOne(d => d.Posiljaoc)
                    .WithMany(p => p.PorukaPosiljaocs)
                    .HasForeignKey(d => d.PosiljaocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Poruka__Posiljao__6FE99F9F");

                entity.HasOne(d => d.Primaoc)
                    .WithMany(p => p.PorukaPrimaocs)
                    .HasForeignKey(d => d.PrimaocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Poruka__PrimaocI__70DDC3D8");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Body)
                    .HasColumnType("text")
                    .HasColumnName("BODY");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__KorisnikID__286302EC");
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId)
                    .HasName("PK__Uloge__DCAB23EB26C01165");

                entity.ToTable("Uloge");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(400);
            });

            modelBuilder.Entity<Uplate>(entity =>
            {
                entity.ToTable("Uplate");

                entity.Property(e => e.UplateId).HasColumnName("UplateID");

                entity.Property(e => e.DatumUplate).HasColumnType("datetime");

                entity.Property(e => e.Iznos).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Uplates)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uplate__Korisnik__02FC7413");
            });

            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.ToTable("Vozilo");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.Property(e => e.Boja).HasMaxLength(20);

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.MarkaVozila).HasMaxLength(50);

                entity.Property(e => e.Naziv).HasMaxLength(30);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Vozilos)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vozilo__Korisnik__2E1BDC42");
            });

            modelBuilder.Entity<Voznja>(entity =>
            {
                entity.ToTable("Voznja");

                entity.Property(e => e.VoznjaId).HasColumnName("VoznjaID");

                entity.Property(e => e.AutomatskoOdobrenje).HasMaxLength(5);

                entity.Property(e => e.Cigarete).HasMaxLength(5);

                entity.Property(e => e.CijenaSjedista).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DatumVoznje).HasColumnType("datetime");

                entity.Property(e => e.EndId).HasColumnName("EndID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.KucniLjubimci)
                    .HasMaxLength(5)
                    .HasColumnName("KucniLJubimci");

                entity.Property(e => e.StartId).HasColumnName("StartID");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.HasOne(d => d.End)
                    .WithMany(p => p.VoznjaEnds)
                    .HasForeignKey(d => d.EndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voznja__EndID__3B75D760");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Voznjas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voznja__Korisnik__398D8EEE");

                entity.HasOne(d => d.Start)
                    .WithMany(p => p.VoznjaStarts)
                    .HasForeignKey(d => d.StartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voznja__StartID__3A81B327");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.Voznjas)
                    .HasForeignKey(d => d.VoziloId)
                    .HasConstraintName("FK__Voznja__VoziloID__3C69FB99");
            });

            modelBuilder.Entity<Zahtjevi>(entity =>
            {
                entity.HasKey(e => e.ZahtjevId)
                    .HasName("PK__Zahtjevi__62CC7BBD2EA343E5");

                entity.ToTable("Zahtjevi");

                entity.Property(e => e.ZahtjevId).HasColumnName("ZahtjevID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.VoznjaId).HasColumnName("VoznjaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Zahtjevis)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zahtjevi__Korisn__160F4887");

                entity.HasOne(d => d.Voznja)
                    .WithMany(p => p.Zahtjevis)
                    .HasForeignKey(d => d.VoznjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zahtjevi__Voznja__17036CC0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
