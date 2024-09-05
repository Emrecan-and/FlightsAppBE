using FlightsAppBE.Mapping;
using FlightsAppBE.Repositories;
using FlightsAppBE.Repository;
using FlightsAppBE.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ServiceReference1;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<FlightsAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightsApp")));

builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyMethod()
              .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
