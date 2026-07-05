using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Identity.ErrorDescribers;
using OnlineExam.Identity.Model;
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

            services.AddIdentityCore<OnlineExamUser>(e =>
            {
                e.User.RequireUniqueEmail = true;
                e.Password.RequiredLength = 8;
                e.Password.RequireUppercase = true;
                e.Password.RequiredUniqueChars = 0;
                e.Password.RequireDigit = true;
                e.Password.RequireLowercase = true;
                e.Password.RequireNonAlphanumeric = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<OnlineExamIdentityDbContext>().AddErrorDescriber<ErrorToFarsi>(); ;
            services.AddScoped<IAuthServices, AuthServices>();
            return services;
        }
    }
}
