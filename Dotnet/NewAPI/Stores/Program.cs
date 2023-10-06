using Stores.Repositories;
using Stores.Repositories.Interfaces;
using Stores.Services;
using Stores.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<IStoreRepository,StoreRepository>();
builder.Services.AddScoped<IStoreService,StoreService>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
