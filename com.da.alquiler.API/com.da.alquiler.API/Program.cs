using com.da.alquiler.API;
using com.da.alquiler.API.AccesoDatos.Repositories.Implementations;
using com.da.alquiler.API.AccesoDatos.Repositories.Interfaces;
using com.da.alquiler.API.AccesoDatos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

#region cadena conexion
var connectionString = builder.Configuration.GetConnectionString("dbSISAL");

builder.Services.AddDbContext<AlquileresDbContext>(
        options => options.UseSqlServer(connectionString)
    );
#endregion

#region Transcient

builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaServices, EmpresaServices>();

#endregion

#region Automapper

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

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
