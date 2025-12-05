using BusinessLayer.Abstrack;
using BusinessLayer.Concrete;
using DataAcessLayerss;
using DataAcessLayerss.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ILicenseRepository,LicenseRepository>();
builder.Services.AddScoped<ILicenseServices, LicenseServices>();
builder.Services.AddScoped<IProdutsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSwaggerGen();


var app = builder.Build();



app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 //   app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
