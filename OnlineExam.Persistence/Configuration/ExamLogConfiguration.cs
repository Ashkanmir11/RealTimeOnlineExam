using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class ExamLogConfiguration : IEntityTypeConfiguration<ExamLog>
    {
        public void Configure(EntityTypeBuilder<ExamLog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.StudentId).IsRequired();
            builder.HasOne(e => e.LogType).WithMany(e => e.examLogs).HasForeignKey(e => e.LogTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
