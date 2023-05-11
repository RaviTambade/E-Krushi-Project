using CatlogService.Repositories;
using CatlogService.Repositories.Interfaces;
using CatlogService.Service;
using CatlogService.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IProductService,ProductService>();

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
app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
