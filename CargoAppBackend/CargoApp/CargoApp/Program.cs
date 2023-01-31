using CargoApp;
using CargoApp.DataAccess;
using CargoApp.Models;
using CargoApp.Repositories;
using CargoApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config AppSettings

var appConfig = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appConfig);
var appSettings = appConfig.Get<AppSettings>();

builder.Services.AddTransient<IRepository<Parcel>, ParcelRepository>();
builder.Services.AddTransient<IParcelService>();

builder.Services.
    AddDbContext<ParcelDbContext>(options => options.UseSqlServer("Server =.;Database=Parcel_DB;Trusted_Connection = True;TrustServerCertificate=True"));
builder.Services.AddCors(options => options.AddPolicy("myPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseCors("myPolicy");


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
