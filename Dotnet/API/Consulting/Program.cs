using Transflower.EKrushi.Consulting.Repositories;
using Transflower.EKrushi.Consulting.Repositories.Interfaces;
using Transflower.EKrushi.Consulting.Services.Interfaces;
using Transflower.EKrushi.Consulting.Services;
using Transflower.EKrushi.Consulting.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IConsultingRepository,ConsultingRepository>();
builder.Services.AddTransient<IConsultingService,ConsultingService>();
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

app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();
