
using E_commorec.infrastructuer;
using E_commorec.infrastructuer.Data.SeedRoleAndAdmin;
using E_comorec.API.Helper;
using E_comorec.API.Middlwaer;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(op =>
            {
                op.InvalidModelStateResponseFactory = context =>
                {
                    APIValidationError error = new APIValidationError
                    {
                        Error = context.ModelState.Where(x => x.Value.Errors.Count() > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage),
                    };
                    return new BadRequestObjectResult(error);
                };
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMemoryCache();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //register infrastructuer
            //builder.Services.infrastructuer(builder.Configuration);
            builder.Services.infrastructuer(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(m => m.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddliWare>();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.MapControllers();
            SeedingRole.Initialize(app.Services);
            app.Run();
        }
    }
}
