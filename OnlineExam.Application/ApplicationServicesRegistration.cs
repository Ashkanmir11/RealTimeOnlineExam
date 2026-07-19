using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Linq;
using System;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Contracts.AIServices;
using OnlineExam.Application.Serviecs;
namespace OnlineExam.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(cfg =>{}, typeof(MappingProfile).Assembly);
            
            services.AddMediatR(cfg =>
            {
                //cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateClassRoomRequest).Assembly);
            });
            services.AddValidatorsFromAssemblyContaining<CreateTrueOrFalseAnswerValidation>();
            services.AddValidatorsFromAssemblyContaining<CreateTrueOrFalseQuestionDTO>();

            services.AddScoped<IAiServices, AiServices>();
        }

    }
}
