using KrushiProject.Helpers;
using KrushiProject.Repositories;
using KrushiProject.Repositories.Interfaces;
using KrushiProject.Service;
using KrushiProject.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<ICustomerService,CustomerService>();


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
