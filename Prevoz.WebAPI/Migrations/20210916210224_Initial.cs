using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prevoz.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CS_AS"),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PasswordSalt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.LokacijaID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloge__DCAB23EB26C01165", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    FAQID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Pitanje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Odgovor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.FAQID);
                    table.ForeignKey(
                        name: "FK__FAQ__KorisnikID__2B3F6F97",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Feedback__Korisn__4CA06362",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    PorukaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosiljaocID = table.Column<int>(type: "int", nullable: false),
                    PrimaocID = table.Column<int>(type: "int", nullable: false),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.PorukaID);
                    table.ForeignKey(
                        name: "FK__Poruka__Posiljao__6FE99F9F",
                        column: x => x.PosiljaocID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Poruka__PrimaocI__70DDC3D8",
                        column: x => x.PrimaocID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BODY = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK__Post__KorisnikID__286302EC",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    UplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    DatumUplate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplateID);
                    table.ForeignKey(
                        name: "FK__Uplate__Korisnik__02FC7413",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    VoziloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    MarkaVozila = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Boja = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.VoziloID);
                    table.ForeignKey(
                        name: "FK__Vozilo__Korisnik__2E1BDC42",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikDetails",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lokacija = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DatumRođenja = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__80B06D614EBF07A9", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK__KorisnikD__Koris__48CFD27E",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KorisnikD__Lokac__49C3F6B7",
                        column: x => x.Lokacija,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK__KorisnikU__Koris__35BCFE0A",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KorisnikU__Uloga__36B12243",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voznja",
                columns: table => new
                {
                    VoznjaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    StartID = table.Column<int>(type: "int", nullable: false),
                    EndID = table.Column<int>(type: "int", nullable: false),
                    VoziloID = table.Column<int>(type: "int", nullable: true),
                    CijenaSjedista = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    BrojSjedista = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    DatumVoznje = table.Column<DateTime>(type: "datetime", nullable: false),
                    AutomatskoOdobrenje = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Cigarete = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    KucniLJubimci = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Detaljnije = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voznja", x => x.VoznjaID);
                    table.ForeignKey(
                        name: "FK__Voznja__EndID__3B75D760",
                        column: x => x.EndID,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Voznja__Korisnik__398D8EEE",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Voznja__StartID__3A81B327",
                        column: x => x.StartID,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Voznja__VoziloID__3C69FB99",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikRezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    VoznjaID = table.Column<int>(type: "int", nullable: false),
                    BrojSjedista = table.Column<int>(type: "int", nullable: true),
                    UkupnoPlaceno = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__CABA44FDD8B8A748", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK__KorisnikR__Koris__3F466844",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KorisnikR__Voznj__403A8C7D",
                        column: x => x.VoznjaID,
                        principalTable: "Voznja",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjevi",
                columns: table => new
                {
                    ZahtjevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    VoznjaID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zahtjevi__62CC7BBD2EA343E5", x => x.ZahtjevID);
                    table.ForeignKey(
                        name: "FK__Zahtjevi__Korisn__160F4887",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Zahtjevi__Voznja__17036CC0",
                        column: x => x.VoznjaID,
                        principalTable: "Voznja",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoznjaID = table.Column<int>(type: "int", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    RezervacijaID = table.Column<int>(type: "int", nullable: true),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK__Ocjena__Korisnik__44FF419A",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ocjena__Rezervac__45F365D3",
                        column: x => x.RezervacijaID,
                        principalTable: "KorisnikRezervacija",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ocjena__VoznjaID__440B1D61",
                        column: x => x.VoznjaID,
                        principalTable: "Voznja",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "KorisnikID", "CreatedAt", "ModifiedAT", "PasswordHash", "PasswordSalt", "Slika", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hkygp3aJFIgOMtbHckDaXN5HYBA=", "DMUTs++b9XRsy8TQxXWtzw==", null, "headadministrator1" },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hkygp3aJFIgOMtbHckDaXN5HYBA=", "DMUTs++b9XRsy8TQxXWtzw==", null, "Korisnik" },
                    { 3, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hkygp3aJFIgOMtbHckDaXN5HYBA=", "DMUTs++b9XRsy8TQxXWtzw==", null, "Korisnik2" },
                    { 4, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hkygp3aJFIgOMtbHckDaXN5HYBA=", "DMUTs++b9XRsy8TQxXWtzw==", null, "Korisnik3" },
                    { 5, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hkygp3aJFIgOMtbHckDaXN5HYBA=", "DMUTs++b9XRsy8TQxXWtzw==", null, "admineditor1" }
                });

            migrationBuilder.InsertData(
                table: "Lokacija",
                columns: new[] { "LokacijaID", "Latitude", "Longitude", "Naziv", "PostalCode" },
                values: new object[,]
                {
                    { 10, "", "", "Visoko", "468484" },
                    { 9, "", "", "Čapljina", "846846" },
                    { 8, "", "", "Banja Luka", "548486" },
                    { 7, "", "", "Bihać", "84584" },
                    { 6, "", "", "Tuzla", "795986" },
                    { 4, "", "", "Grude", "213213" },
                    { 3, "", "", "Zenica", "1233" },
                    { 2, "", "", "Sarajevo", "2231" },
                    { 1, "", "", "Mostar", "88000" },
                    { 5, "", "", "Livno", "1231231" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 2, "korisnik", "Korisnik funkcionalnosti aplikacije" },
                    { 1, "admin/editor", "Permisije nad upravljanjem korisnicima, (Uklanjanje korisnika i dodijeljivanje permisije (admin/editor) nekom od korisnika" },
                    { 3, "headadmin", "Permisije nad upravljanjem korisnicima, (Uklanjanje korisnika i dodijeljivanje permisije (admin/editor) nekom od korisnika, mogućnost uklanjanja (admineditor) korisnika i oduzimanja permisija i dodijeljivanja istih." }
                });

            migrationBuilder.InsertData(
                table: "FAQ",
                columns: new[] { "FAQID", "KorisnikID", "Odgovor", "Pitanje" },
                values: new object[,]
                {
                    { 1, 2, "", "Pitanje br.1" },
                    { 2, 2, "", "Pitanje br.1" },
                    { 3, 2, "", "Pitanje br.1" },
                    { 4, 3, "", "Pitanje br.2" },
                    { 5, 3, "", "Pitanje br.2" },
                    { 6, 3, "", "Pitanje br.2" }
                });

            migrationBuilder.InsertData(
                table: "KorisnikDetails",
                columns: new[] { "KorisnikID", "DatumRođenja", "Email", "Ime", "Lokacija", "Prezime", "Telefon" },
                values: new object[,]
                {
                    { 4, new DateTime(1992, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@gmail.com", "user4", 4, "user4", "4745476" },
                    { 3, new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@gmail.com", "user3", 3, "user3", "945124906" },
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "headadmin@edu.fit.ba", "headadmin", 1, "headadmin", "124578324" },
                    { 2, new DateTime(1993, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "korisnik@gmail.com", "Korisnik", 2, "Korisnik", "521353795" },
                    { 5, new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admineditor@edu.fit.ba", "admineditor", 2, "admineditor", "246790212" }
                });

            migrationBuilder.InsertData(
                table: "KorisnikUloga",
                columns: new[] { "KorisnikUlogaID", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 5, 5, 3 },
                    { 3, 3, 2 },
                    { 2, 2, 2 },
                    { 1, 1, 1 },
                    { 4, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostID", "BODY", "KorisnikID", "Title" },
                values: new object[] { 1, "Ovo može biti tvoje najbolje i najjeftinije putovanje do sada", 1, "Tražiš prevoz" });

            migrationBuilder.InsertData(
                table: "Uplate",
                columns: new[] { "UplateID", "DatumUplate", "Iznos", "KorisnikID" },
                values: new object[] { 1, null, 100m, 2 });

            migrationBuilder.InsertData(
                table: "Vozilo",
                columns: new[] { "VoziloID", "Boja", "KorisnikID", "MarkaVozila", "Naziv", "Slika" },
                values: new object[,]
                {
                    { 3, "Siva", 3, "Volkswagen", "Passat 8", null },
                    { 2, "Crna", 2, "BMW", "BMW 5", null },
                    { 1, "Bijela", 1, "Volkswagen", "Golf 7", null },
                    { 5, "Crvena", 5, "Audi", "Audi A5", null },
                    { 4, "Crna", 4, "Mercedes", "Golf 5", null }
                });

            migrationBuilder.InsertData(
                table: "Voznja",
                columns: new[] { "VoznjaID", "AutomatskoOdobrenje", "BrojSjedista", "Cigarete", "CijenaSjedista", "DatumVoznje", "Detaljnije", "EndID", "KorisnikID", "KucniLJubimci", "StartID", "STATUS", "VoziloID" },
                values: new object[,]
                {
                    { 1, null, 3, null, 5m, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, 1, true, 2 },
                    { 3, null, 3, null, 7m, new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, 2, true, 2 },
                    { 10, null, 3, null, 22m, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, null, 4, true, 2 },
                    { 11, null, 3, null, 10m, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 2, null, 5, true, 2 },
                    { 15, null, 3, null, 5m, new DateTime(2020, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, 1, true, 2 },
                    { 2, null, 3, null, 6m, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, null, 1, true, 3 },
                    { 4, null, 3, null, 10m, new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, null, 3, true, 3 },
                    { 5, null, 3, null, 12m, new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 3, null, 4, true, 3 },
                    { 6, null, 3, null, 15m, new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 3, null, 5, true, 3 },
                    { 12, null, 3, null, 6m, new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 4, null, 5, true, 3 },
                    { 13, null, 3, null, 10m, new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, null, 10, true, 3 },
                    { 14, null, 3, null, 10m, new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 3, null, 9, true, 3 },
                    { 7, null, 3, null, 7m, new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 4, null, 6, true, 4 },
                    { 8, null, 3, null, 8m, new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, null, 7, true, 4 },
                    { 9, null, 3, null, 11m, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, null, 8, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "KorisnikRezervacija",
                columns: new[] { "RezervacijaID", "BrojSjedista", "DatumRezervacije", "KorisnikID", "UkupnoPlaceno", "VoznjaID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5m, 1 },
                    { 7, 1, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8m, 8 },
                    { 4, 1, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8m, 8 },
                    { 3, 1, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7m, 7 },
                    { 18, 1, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7m, 13 },
                    { 12, 1, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10m, 13 },
                    { 11, 1, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6m, 12 },
                    { 9, 1, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6m, 12 },
                    { 20, 1, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 15m, 6 },
                    { 5, 1, new DateTime(2020, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11m, 9 },
                    { 19, 1, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10m, 4 },
                    { 14, 1, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5m, 2 },
                    { 8, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11m, 9 },
                    { 17, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5m, 15 },
                    { 16, 1, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5m, 15 },
                    { 15, 1, new DateTime(2020, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5m, 15 },
                    { 10, 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5m, 1 },
                    { 13, 1, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7m, 1 },
                    { 2, 1, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6m, 2 },
                    { 6, 1, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 22m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Ocjena",
                columns: new[] { "OcjenaID", "Komentar", "KorisnikID", "Ocjena", "RezervacijaID", "VoznjaID" },
                values: new object[,]
                {
                    { 4, "Odličan vozač", 4, 5, null, 2 },
                    { 6, "Ugodna vožnja", 2, 5, null, 12 },
                    { 1, "Ugodna vožnja, preporuke.", 4, 5, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Zahtjevi",
                columns: new[] { "ZahtjevID", "Datum", "KorisnikID", "Status", "VoznjaID" },
                values: new object[,]
                {
                    { 10, new DateTime(2020, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 15 },
                    { 2, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 7 },
                    { 9, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 14 },
                    { 3, new DateTime(2021, 9, 16, 23, 2, 23, 944, DateTimeKind.Local).AddTicks(6044), 2, null, 12 },
                    { 6, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1 },
                    { 7, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 10 },
                    { 8, new DateTime(2020, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 11 },
                    { 5, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 6 },
                    { 1, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 13 },
                    { 4, new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Ocjena",
                columns: new[] { "OcjenaID", "Komentar", "KorisnikID", "Ocjena", "RezervacijaID", "VoznjaID" },
                values: new object[] { 2, "Preporučujem kao saputnika.", 2, 5, 10, null });

            migrationBuilder.InsertData(
                table: "Ocjena",
                columns: new[] { "OcjenaID", "Komentar", "KorisnikID", "Ocjena", "RezervacijaID", "VoznjaID" },
                values: new object[] { 3, "Odlična osoba, dobar saputnik, preporučujem.", 3, 5, 14, null });

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_KorisnikID",
                table: "FAQ",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_KorisnikID",
                table: "Feedback",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikDetails_Lokacija",
                table: "KorisnikDetails",
                column: "Lokacija");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikRezervacija_KorisnikID",
                table: "KorisnikRezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikRezervacija_VoznjaID",
                table: "KorisnikRezervacija",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikID",
                table: "KorisnikUloga",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaID",
                table: "KorisnikUloga",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KorisnikID",
                table: "Ocjena",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_RezervacijaID",
                table: "Ocjena",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_VoznjaID",
                table: "Ocjena",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_PosiljaocID",
                table: "Poruka",
                column: "PosiljaocID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_PrimaocID",
                table: "Poruka",
                column: "PrimaocID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_KorisnikID",
                table: "Post",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_KorisnikID",
                table: "Uplate",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_KorisnikID",
                table: "Vozilo",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznja_EndID",
                table: "Voznja",
                column: "EndID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznja_KorisnikID",
                table: "Voznja",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznja_StartID",
                table: "Voznja",
                column: "StartID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznja_VoziloID",
                table: "Voznja",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_KorisnikID",
                table: "Zahtjevi",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_VoznjaID",
                table: "Zahtjevi",
                column: "VoznjaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "KorisnikDetails");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Poruka");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "Zahtjevi");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "KorisnikRezervacija");

            migrationBuilder.DropTable(
                name: "Voznja");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
