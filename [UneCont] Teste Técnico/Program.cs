using _UneCont__Teste_T�cnico.Data;
using _UneCont__Teste_T�cnico.Data.Interfaces;
using _UneCont__Teste_T�cnico.Data.Repositories;
using _UneCont__Teste_T�cnico.Services.Auxiliares;
using _UneCont__Teste_T�cnico.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Unecont.NfseApi.Data.Repositories;
using Unecont.NfseApi.Mappers;
using Unecont.NfseApi.Services.NotasFiscaisServices;

var builder = WebApplication.CreateBuilder(args);

//ConnString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Dentro do escopo da requisi��o (Scoped)
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
// XmlProcessor sem estado de requisicao (Transient)
builder.Services.AddTransient<XmlProcessor>();
// L�gica de neg�cios (Scoped)
builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
