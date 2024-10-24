using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using AdiantamentoRecebiveis.API.Extensions;
using AdiantamentoRecebiveis.API.Ioc;
using AdiantamentoRecebiveis.Application.IoC;
using AdiantamentoRecebiveis.Application.Utils;
using AdiantamentoRecebiveis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

//Add Services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    opt.IncludeXmlComments(xmlPath);
    opt.DescribeAllParametersInCamelCase();
});

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.RegistrarApplicationDependency();


//Dependecy Load
Ioc.LoadDependencyInjection(builder.Services);

//AppSettings Load
AppSettings.LoadSettings(builder.Configuration);

var teste = AppSettings.ConnectionString;

//For automatic generate add apply migrations
builder.Services.AddDbContext<DataContext>(
    conn => conn.UseSqlServer("Server=JOEL\\SQLEXPRESS;Database=testedb;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterControllers();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
