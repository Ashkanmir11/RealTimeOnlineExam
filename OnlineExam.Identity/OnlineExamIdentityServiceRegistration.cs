using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Profile;
using OnlineExam.Identity.ErrorDescribers;
using OnlineExam.Identity.Model;
using OnlineExam.Identity.Profile;
using OnlineExam.Identity.Repositories;
using OnlineExam.Identity.SeedData;
using OnlineExam.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineExam.Identity
{
    public static class OnlineExamIdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var connetionString = configuration.GetConnectionString("OnlineExamIdentityConnectionString");
            services.AddDbContext<OnlineExamIdentityDbContext>(option => option.UseSqlServer(connetionString));

            services.AddIdentityCore<OnlineExamUser>(e =>
            {
                e.User.RequireUniqueEmail = true;
                e.Password.RequiredLength = 8;
                e.Password.RequireUppercase = true;
                e.Password.RequireDigit = true;
                e.Password.RequireLowercase = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<OnlineExamIdentityDbContext>().AddDefaultTokenProviders().AddErrorDescriber<ErrorToFarsi>(); ;
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<TokenServices>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
              {
                  //jwt setting
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = configuration["JwtSettings:Issuer"],
                      ValidAudience = configuration["JwtSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                  };
                  //for read from request header
                  o.Events = new JwtBearerEvents
                  {
                      OnMessageReceived = context =>
                      {
                          context.Token = context.Request.Cookies["accessToken"];
                          return Task.CompletedTask;
                      }
                  };
              });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddAutoMapper(cfg => { }, typeof(IdentityMappingProfile).Assembly);

            return services;
        }
    }
}
