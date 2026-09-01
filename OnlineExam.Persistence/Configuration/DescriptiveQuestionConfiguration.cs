using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class DescriptiveQuestionConfiguration : IEntityTypeConfiguration<DescriptiveQuestion>
    {
        public void Configure(EntityTypeBuilder<DescriptiveQuestion> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CorrectAnswer).HasMaxLength(1000);

            builder.HasMany(e => e.Answers).WithOne(e => e.DescriptiveQuestion).HasForeignKey(e => e.DescriptiveQuestionId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
