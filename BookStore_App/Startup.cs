using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Interface;
using RepositoryLayer.Repository;
using RepositoryLayer.Service;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace BookStore_App
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
            services.AddControllers();

            services.AddDbContext<BookStoreDbContext>(option => option.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnection")));            

            services.AddScoped<IRegistrationBL, RegistrationBL>();
            services.AddScoped<IRegistrationRL, RegistrationRL>();
            services.AddScoped<IBooksBL, BooksBL>();
            services.AddScoped<IBooksRL, BooksRL>();
            services.AddScoped<ICartBL, CartBL>();
            services.AddScoped<ICartRL, CartRL>();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookStore",
                    Description = "Implementation of BookStore",
                    TermsOfService = new Uri("https://www.bridgelabz.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohammad Abid Shaikh",
                        Email = "shaikhabid332@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/theabidshaikh/"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddAuthentication(option=>{
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Environment.GetEnvironmentVariable("jwtIssuer"),
                     ValidAudience = Environment.GetEnvironmentVariable("jwtAudience"),
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("jwtKey")))
                };
            });            

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();            

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
