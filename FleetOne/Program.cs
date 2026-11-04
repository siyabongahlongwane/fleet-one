using FleetOne.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Get db connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Register DbContext using the Postgres provider
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(connectionString)); // <-- This extension method comes from Npgsql

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); 
}
else
{
app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();

app.Run();