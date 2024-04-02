using Avaliacao1.Endpoints;
using Avaliacao1.JonStore.Repository;
using Avaliacao1.JonStore.Repository.Context;
using Avaliacao1.JonStore.Service;
using Avaliacao1.JonStore.Service.Interfaces;
using Avaliacao1.JonStore.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JonStoreDbContext>(options =>
{
    options.UseInMemoryDatabase("TestDB");
});

builder.Services.AddServiceDependency();
builder.Services.AddRepositoryDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddJonStoreEndpoints();

app.Run();
