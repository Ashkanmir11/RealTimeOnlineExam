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
        public DbSet<ClassRoomMembers> ClassRoomMembers { get; set; }
        public DbSet<DescriptiveQuestion> DescriptiveQuestions { get; set; }
        public DbSet<DescriptiveAnswers> DescriptiveAnswers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamAttampt> ExamAttampts { get; set; }
        public DbSet<ExamLog> ExamsLogs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceAnswers> MultipleChoiceAnswers { get; set; }
        public DbSet<Objection> Objections { get; set; }
        public DbSet<TrueOrFalseQuestion> TrueOrFalseQuestions { get; set; }
        public DbSet<TrueOrFalseAnswers> TrueOrFalseAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClassRoomConfiguration());
            builder.ApplyConfiguration(new ClassRoomMembersConfiguration());
            builder.ApplyConfiguration(new DescriptiveAnswersConfiguration());
            builder.ApplyConfiguration(new DescriptiveQuestionConfiguration());
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new ExamLogConfiguration());
            builder.ApplyConfiguration(new LogTypeConfiguration());
            builder.ApplyConfiguration(new MultipleChoiceAnswersConfiguration());
            builder.ApplyConfiguration(new MultipleChoiceQuestionConfiguration());
            builder.ApplyConfiguration(new ObjectionConfiguration());
            builder.ApplyConfiguration(new TrueOrFalseAnswersConfiguration());
            builder.ApplyConfiguration(new TrueOrFalseQuestionConfiguration());
            builder.ApplyConfiguration(new ExamAttamptConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
