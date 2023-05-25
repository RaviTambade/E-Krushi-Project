using E_krushiApp.Repositories;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using E_krushiApp.Services.AgriDoctors;
using E_krushiApp.Repository.Interface;
using E_krushiApp.Repository;
using E_krushiApp.Services.Interface;
using E_krushiApp.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAgriRepository,AgriRepository>();
builder.Services.AddTransient<IAgriDoctorsService,AgriDoctorsService>();
builder.Services.AddTransient<IQuestionRepository,QuestionRepository>();
builder.Services.AddTransient<IQuestionService,QuestionService>();
builder.Services.AddTransient<ISolutionRepository,SolutionRepository>();
builder.Services.AddTransient<ISolutionService,SolutionService>();
builder.Services.AddTransient<IQuestionSolutionRepository,QuestionSolutionRepository>();
builder.Services.AddTransient<IQuestionSolutionService,QuestionSolutionService>();
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
app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.MapControllers();

app.Run();
