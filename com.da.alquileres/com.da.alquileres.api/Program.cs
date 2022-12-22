using com.da.alquileres.accesodatos.Implementations;
using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api;
using com.da.alquileres.api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//Configurando Automapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaServices, EmpresaServices>();

var app = builder.Build();

//
var connectionString = builder.Configuration.GetConnectionString("dbSISAL");

builder.Services.AddDbContext<AlquileresDbContext>(
        options => options.UseSqlServer(connectionString)
    );

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
