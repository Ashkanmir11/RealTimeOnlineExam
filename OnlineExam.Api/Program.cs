using Microsoft.OpenApi.Models;
using OnlineExam.Api.Herlpers;
using OnlineExam.Api.Middleware;
using OnlineExam.Identity;
using OnlineExam.Identity.SeedData;
using OnlineExam.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

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
builder.Services.ConfigurePersistenceServices(builder.Configuration);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var OnlineExamContext = services.GetRequiredService<OnlineExamDbContext>();
    await OnlineExamContext.Database.MigrateAsync();

    var OnlineExamIdentityDbContext = services.GetRequiredService<OnlineExamIdentityDbContext>();
    await OnlineExamIdentityDbContext.Database.MigrateAsync();
    await IdentitySeed.Seed(services);
}

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

