var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//builder.Services.Configure<AppSettings>(builder.Configuration);

//builder.Services.AddDbContext<ECommerceDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));

//    options.EnableSensitiveDataLogging(false);
//});

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
