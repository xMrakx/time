using CDShopApp.Infrastructure;
using CDShopApp.Services;
using Microsoft.EntityFrameworkCore;
using CDShopApp.Infrastructure.Data.CDModel;
using CDShopApp.Infrastructure.UoW;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CDContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {

    }
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICDRepository, CDRepository>();
builder.Services.AddScoped<ICDService, CDService>();

/*
builder.Services.AddScoped<ICDRepository>(s =>
    new CDRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICDService, CDService>();
*/

var app = builder.Build();
app.MapControllers();
app.Run();
app.UseCors(x => x
    .WithOrigins("http://localhost:4200")
    .AllowCredentials()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
