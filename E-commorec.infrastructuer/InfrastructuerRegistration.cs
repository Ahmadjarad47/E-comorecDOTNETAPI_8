using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.core.Services;
using E_commorec.infrastructuer.Data;
using E_commorec.infrastructuer.Repositries;
using E_commorec.infrastructuer.Repositries.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace E_commorec.infrastructuer
{
    public static class InfrastructuerRegistration
    {
        public static IServiceCollection infrastructuer(this IServiceCollection services, IConfiguration configure)
        {


            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configure.GetConnectionString("URL_Connection"));

            }, ServiceLifetime.Transient);

            services.AddHostedService<RunInBackgroundServices>();


            services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositries<>));

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));


            services.AddScoped<IGenerateTokenService, GenerateTokenRepositries>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Register UserManager<AppUsers>
            services.AddIdentity<AppUsers, IdentityRole>(op =>
            {
                op.Password.RequiredLength = 7;
                op.Password.RequireNonAlphanumeric = true;
                op.Password.RequireUppercase = true;
                op.Password.RequireLowercase = true;
                op.Password.RequiredUniqueChars = 2;
                op.SignIn.RequireConfirmedEmail = true;

            }).AddRoleManager<RoleManager<IdentityRole>>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(3);

            });


            services.AddScoped<IEmailService, EmailService>();

            //Add Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
   .AddCookie(x =>
   {
       x.Cookie.Name = "token";
   })
   .AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configure["Token:Secret"])),
           ValidateIssuer = true,
           ValidIssuer = configure["Token:Issuer"],
           ValidateAudience = false,
           ClockSkew = TimeSpan.Zero
       };
       x.Events = new JwtBearerEvents()
       {
           OnMessageReceived = context =>
           {
               context.Token = context.Request.Cookies["token"];
               return Task.CompletedTask;
           }
       };
   });


            services.AddSwaggerGen(op =>
            {
                OpenApiSecurityScheme securty = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "jwt Auth Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                op.AddSecurityDefinition("Bearer", securty);

                OpenApiSecurityRequirement SR = new OpenApiSecurityRequirement { { securty, new[] { "Bearer" } } };

                op.AddSecurityRequirement(SR);
            });

            return services;
        }
    }
}
