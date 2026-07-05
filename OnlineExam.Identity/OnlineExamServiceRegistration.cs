using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity
{
    public static class OnlineExamServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connetionString = configuration.GetConnectionString("OnlineExamIdentityConnectionString");
            services.AddDbContext<OnlineExamIdentityDbContext>(option => option.UseSqlServer(connetionString));

            services.AddScoped<IAuthServices, AuthServices>();
            return services;
        }
    }
}
