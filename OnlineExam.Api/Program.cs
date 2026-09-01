using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Api.Configuration;
using OnlineExam.Api.Herlpers;
using OnlineExam.Api.Hubs;
using OnlineExam.Api.Middleware;
using OnlineExam.Application;
using OnlineExam.Identity;
using OnlineExam.Identity.SeedData;
using OnlineExam.Persistence;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", b =>
{
    b.WithOrigins("https://localhost:7207", "http://localhost:5139");
    b.AllowAnyHeader();
    b.AllowAnyMethod();
    b.AllowCredentials();
}));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CookieHelper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureVersioningServices();
builder.Services.AddSignalR();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var onlineExamContext = services.GetRequiredService<OnlineExamDbContext>();
    await onlineExamContext.Database.MigrateAsync();

    var onlineExamIdentityDbContext = services.GetRequiredService<OnlineExamIdentityDbContext>();
    await onlineExamIdentityDbContext.Database.MigrateAsync();
    await IdentitySeed.Seed(services);
}
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.MapHub<ExamHub>("/StartExam");
app.Run();

