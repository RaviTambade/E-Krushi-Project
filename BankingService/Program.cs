using BankingService.Repositories;
using BankingService.Repositories.Interfaces;
using BankingService.Service.Interfaces;
using BankingService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IAccountRepository,AccountRepository>();
builder.Services.AddTransient<IAccountService,AccountService>();
builder.Services.AddTransient<ITransactionRepository,TransactionRepository>();
builder.Services.AddTransient<ITransactionService,TransactionService>();
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

app.MapControllers();

app.Run();
