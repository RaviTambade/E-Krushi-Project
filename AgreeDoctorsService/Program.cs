using E_krushiApp.Repositories;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using E_krushiApp.Services.AgriDoctors;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAgri,Agri>();
builder.Services.AddTransient<IAgriDoctorsService,AgriDoctorsService>();


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
