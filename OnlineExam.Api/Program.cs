using Microsoft.OpenApi.Models;
using OnlineExam.Api.Herlpers;
using OnlineExam.Api.Middleware;
using OnlineExam.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TODO create Seperate File for services
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CookieHelper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentityServices(builder.Configuration);
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
app.UseMiddleware<ExceptionMiddleware>();
app.Run();

