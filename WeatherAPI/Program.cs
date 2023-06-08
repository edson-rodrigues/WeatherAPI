using Integracao.Interfaces;
using Refit;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var openWeatherAdress = builder.Configuration["ExternalAPIs:WeatherAPI"];
var openGeoAdress = builder.Configuration["ExternalAPIs:GeoLocationAPI"];


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRefitClient<IOpenWeatherHttp>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(openWeatherAdress)
                             ); 
builder.Services.AddRefitClient<IOpenGeoHttp>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(openGeoAdress)
        );
        
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
