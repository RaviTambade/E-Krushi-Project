using Transflower.EKrushi.PaymentsAPI.InterFaces;
using Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IPaymentDetailsRepository,PaymentDetailsRepository>();
builder.Services.AddTransient<IPaymentRepository,PaymentRepository>();
builder.Services.AddTransient<IPaymentDetailsService,PaymentDetailsService>();
builder.Services.AddTransient<IPaymentService,PaymentService>();
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
