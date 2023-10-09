using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Models;

var builder = WebApplication.CreateBuilder(args);

// adiciona um banco de dados usando string de conexão
builder.Services.AddDbContext<AppDataContext>(
    options => options.UseSqlite("Data Source = ecommerce.db;Cache=shared")
    // depois do igual você coloca o nome do projeto que quer dar
);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
