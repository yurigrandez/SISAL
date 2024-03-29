using com.da.alquileres.accesodatos.Implementations;
using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api;
using com.da.alquileres.api.AccesoDatos.Repository.Implementations;
using com.da.alquileres.api.AccesoDatos.Repository.Interfaces;
using com.da.alquileres.api.AccesoDatos.Services;
using com.da.alquileres.api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

#region Configurando Automapper

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

#endregion 

#region Cadena de Conexion

var connectionString = builder.Configuration.GetConnectionString("dbSISAL");

builder.Services.AddDbContext<AlquileresDbContext>(
        options => options.UseSqlServer(connectionString)
    );

#endregion

#region Transient

builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaServices, EmpresaServices>();
builder.Services.AddTransient<IToolsRepository, ToolsRepository>();
builder.Services.AddTransient<ILocalPrincipalRepository, LocalPrincipalRepository>();
builder.Services.AddTransient<ILocalPrincipalServices, LocalPrincipalServices>();

#endregion

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
