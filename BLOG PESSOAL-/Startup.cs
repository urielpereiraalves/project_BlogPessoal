using BLOG_PESSOAL_.src.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BLOG_PESSOAL_.src.repositorios;
using BLOG_PESSOAL_.src.repositorios.implementacoes;
using Microsoft.OpenApi.Models;
using BLOG_PESSOAL_.src.servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;
using System.Reflection;

namespace BLOG_PESSOAL_
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
            // Configura��p Banco de Dados
            services.AddDbContext<BlogPessoalContexto>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            // Configura��o Repositorios
            services.AddScoped<IUsuario, UsuarioRepositorio>();
            services.AddScoped<ITema, TemaRepositorio>();
            services.AddScoped<IPostagem, PostagemRepositorio>();

            // Controladores
            services.AddCors();
            services.AddControllers();

            // Configura��o de Servi�os
            services.AddScoped<IAutenticacao, AutenticacaoServicos>();

            // Configura��o do Token Autentica��o JWTBearer
            var chave = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Configura��o Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog Pessoal", Version = "v1" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT authorization header utiliza: Bearer + JWT Token",
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlogPessoalContexto contexto)
        {
            // Ambiente de Desenvolvimento
            if (env.IsDevelopment())
            {
                contexto.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogPessoal v1"));
            }

            // Ambiente de produ��o
            // Rotas
            app.UseRouting();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // Autentica��o e Autoriza��o
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}