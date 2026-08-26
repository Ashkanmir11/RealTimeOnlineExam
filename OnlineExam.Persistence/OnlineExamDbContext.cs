using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Common;
using OnlineExam.Domain.Entities;
using OnlineExam.Persistence.Configuration;

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

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
