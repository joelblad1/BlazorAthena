using AthenaResturantWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using AthenaResturantWebAPI.Controllers;
using AthenaResturantWebAPI.Services; // Add the appropriate namespace for ProductServices

namespace AthenaResturantWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();

            // AddScoped for ProductServices
            builder.Services.AddScoped<ProductService>();

            // AddHttpClient registration
            builder.Services.AddHttpClient();


            // CORS configuration
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS middleware
            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.MapSubCategoryEndpoints();

            app.Run();
        }
    }
}
