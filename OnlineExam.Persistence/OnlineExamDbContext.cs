using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Entities;
using OnlineExam.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence
{
    public class OnlineExamDbContext : DbContext
    {
        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> options) : base(options)
        {

        }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamLog> ExamsLogs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Objection> Objections { get; set;}
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClassRoomConfiguration());
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new ExamLogConfiguration());
            builder.ApplyConfiguration(new LogTypeConfiguration());
            builder.ApplyConfiguration(new ObjectionConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new QuestionTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
