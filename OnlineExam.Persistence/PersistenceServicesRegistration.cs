using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.Contracts;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Persistence.Repositories;

namespace OnlineExam.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OnlineExamConnectionString");
            services.AddDbContext<OnlineExamDbContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IClassRoomMembersRepository, ClassRoomMembersRepository>();
            services.AddScoped<IDescriptiveQuestionRepository, DescriptiveQuestionRepository>();
            services.AddScoped<IDescriptiveAnswersRepository, DescriptiveAnswersRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamLogRepository, ExamLogRepository>();
            services.AddScoped<ILogTypeRepository, LogTypeRepository>();
            services.AddScoped<IMultipleChoiceQuestionRepository, MultipleChoiceQuestionRepository>();
            services.AddScoped<IMultipleChoiceAnswersRepository, MultipleChoiceAnswersRepository>();
            services.AddScoped<IObjectionRepository, ObjectionRepository>();
            services.AddScoped<ITrueOrFalseQuestionRepository, TrueOrFalseQuestionRepository>();
            services.AddScoped<ITrueOrFalseAnswersRepository, TrueOrFalseAnswersRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IExamAttamptRepository, ExamAttamptRepository>();
            return services;
        }
    }
}
