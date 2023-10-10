using CookieStandApi.Data;
using CookieStandApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CookieStandAPI.Models.Interfaces;

namespace CookieStandAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<CookieStandDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddTransient<ICookieStand, CookieStandService>();
          
           // builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            var app = builder.Build();

           
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}