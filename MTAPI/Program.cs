using BusinessLayer.Abstrack;
using BusinessLayer.Concrete;
using DataAcessLayerss;
using DataAcessLayerss.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MTAPI.Extansions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureServiceWrapper();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<AppDbContext>>();

app.Warning(logger);

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

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
