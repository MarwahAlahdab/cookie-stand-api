using System.Collections.Generic;
using Cookie_stand_api.Data;
using Cookie_stand_api.Models.Interfaces;
using Cookie_stand_api.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


string connString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<CookieStandDBContext>(options =>
{
    options.UseSqlServer(connString);
});

builder.Services.AddTransient<ICookieStandService, CookieStandService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

