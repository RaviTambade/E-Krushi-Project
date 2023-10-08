using Shippers.Repositories;
using Shippers.Repositories.Interfaces;
using Shippers.Services;
using Shippers.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<IShipperRepository,ShipperRepository>();
builder.Services.AddScoped<IShipperService,ShipperService>();
builder.Services.AddHttpClient();
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
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
