using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class ExamAttamptConfiguration : IEntityTypeConfiguration<ExamAttampt>
    {
        public void Configure(EntityTypeBuilder<ExamAttampt> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.ExamId });
            builder.Property(e => e.StartDate).IsRequired();
            builder.HasOne(e => e.Exam).WithMany(e => e.ExamAttampts).HasForeignKey(e => e.ExamId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
