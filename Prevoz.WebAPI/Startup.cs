using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Prevoz.WebAPI.Database;
using Prevoz.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prevoz.WebAPI.FIlters;
using Prevoz.Model;
using Prevoz.WebAPI.Services.Feedback;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services;
using Prevoz.WebAPI.Services.Lokacija;
using Prevoz.WebAPI.Services.Vožnja;
using Prevoz.WebAPI.Services;
using Prevoz.Model.Requests.Feedback;
using Prevoz.Model.Requests.Post;
using Prevoz.Model.Requests.Vožnja;
using Prevoz.Model.Requests.Vozilo;
using Prevoz.Model.Requests;
using Prevoz.Model.Requests.Korisnik;
using Prevoz.Model.Requests.Rezervacija;
using Prevoz.Model.Requests.Lokacija;
using Prevoz.Model.Requests.FAQ;
using Microsoft.AspNetCore.Authentication;
using eProdaja.WebAPI.Security;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Prevoz.WebAPI.Services.Rezervacija;
using Prevoz.Model.Requests.Ocjena;
using Prevoz.WebAPI.Services.Ocjena;
using Prevoz.Model.Requests.Uloge;
using Prevoz.WebAPI.Services.Uloge;
using Prevoz.Model.Requests.Poruka;
using Prevoz.WebAPI.Services.Poruka;
using Stripe;
using Prevoz.Model.Requests.Uplate;
using Prevoz.Model.Requests.Zahtjevi;
using Prevoz.WebAPI.Services.Zahtjevi;

namespace Prevoz.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            StripeConfiguration.ApiKey = appSettings.SecretKey;

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                                
                            },
                           new string[] {}
                    }
                });
            });
            services.AddControllers();
            services.AddRouting();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<IKorisnikDetailService, KorisnikDetailServices>();

            services.AddScoped<ICRUDService<Model.Uplate, UplateSearchRequest, UplateUpsertRequest, UplateUpsertRequest>, BaseCRUDService<Model.Uplate, UplateSearchRequest, Database.Uplate, UplateUpsertRequest, UplateUpsertRequest>>();

            services.AddScoped<IService<Model.Ocjena, object>, BaseService <Model.Ocjena, object, Database.Ocjena>>();

            services.AddScoped<ICRUDService<Model.Poruka, PorukaSearchRequest, PorukaUpsertRequest, PorukaUpsertRequest>, PorukaService>();

            services.AddScoped<ICRUDService<Model.Faq, FaqSearchRequest, FaqUpsertRequest, FaqUpsertRequest>, BaseCRUDService<Model.Faq, FaqSearchRequest, Database.Faq, FaqUpsertRequest, FaqUpsertRequest>>();

            services.AddScoped<ICRUDService<Model.Feedback, FeedbackSearchRequest, FeedbackUpsertRequest, FeedbackUpsertRequest>, FeedbackService>();
            
            services.AddScoped<ICRUDService<Model.Zahtjevi, ZahtjeviSearchRequest, ZahtjeviUpsertRequest, ZahtjeviUpsertRequest>, ZahtjeviService>();
            
            services.AddScoped<ICRUDService<Model.Lokacija, LokacijaSearchRequest,LokacijaUpsertRequest, LokacijaUpsertRequest>, LokacijaService>();
                       
            services.AddScoped<ICRUDService<Model.Voznja, VoznjaSearchRequest, VoznjaUpsertRequest, VoznjaUpsertRequest>, VoznjaService>();
            
            services.AddScoped<ICRUDService<Model.Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest>, VoziloService>();
            
            services.AddScoped<ICRUDService<Model.Ocjena, OcjenaSearchRequest, OcjenaUpsertRequest, OcjenaUpsertRequest>, OcjenaService>();
            
            services.AddScoped<ICRUDService<Model.Uloge, UlogeSearchRequest, UlogeUpsertRequest, UlogeUpsertRequest>, UlogeService>();
           
            services.AddScoped<ICRUDService<Model.KorisnikUloge, KorisnikUlogeSearchRequest, KorisnikUlogeUpsertRequest, KorisnikUlogeUpsertRequest>, KorisnikUlogeService>();

            services.AddScoped<ICRUDService<Model.KorisnikRezervacija, KorisnikRezervacijaSearchRequest, KorisnikRezervacijaUpsertRequest, KorisnikRezervacijaUpsertRequest>, KorisnikRezervacijaService>();

            services.AddScoped<ICRUDService<Model.Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest>, BaseCRUDService<Model.Post,PostSearchRequest,Database.Post,PostUpsertRequest,PostUpsertRequest>>();
            

            services.AddDbContext<PrevozContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PrevozContext")));
     
            services.AddMvc(x=>x.Filters.Add<ErrorFilter>());
        }
     
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=KorisnikController}/{action=Get}");
                endpoints.MapControllers();
                // Create routes for Web API and SignalR here too..
            });
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
