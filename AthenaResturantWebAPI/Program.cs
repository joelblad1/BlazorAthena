using AthenaResturantWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using AthenaResturantWebAPI.Controllers;
using AthenaResturantWebAPI.Services;
using Microsoft.AspNetCore.Identity;
using System;
using AthenaResturantWebAPI.Data.AppUser;

namespace AthenaResturantWebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            // Register Identity services
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddRoles<IdentityRole>()  // Add this line to enable roles
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                // Obtain the necessary services
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>(); 
                // Call the SeedData method
                var seedDataService = new GeneralServices(appDbContext,userManager, roleManager);
                await seedDataService.SeedData(appDbContext, userManager, roleManager);

            }




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
