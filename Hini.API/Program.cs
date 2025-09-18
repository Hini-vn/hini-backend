using Hini.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Hini.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HiniDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext"),
                    providerOptions => providerOptions.EnableRetryOnFailure());
            });
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            
            var app = builder.Build();
            if(app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("My API");
                    options.WithTheme(ScalarTheme.BluePlanet);
                    options.WithSidebar();
                });
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}