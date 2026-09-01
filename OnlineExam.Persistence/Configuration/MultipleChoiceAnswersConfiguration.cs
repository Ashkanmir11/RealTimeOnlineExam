using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class MultipleChoiceAnswersConfiguration : IEntityTypeConfiguration<MultipleChoiceAnswers>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.StudentScore).HasPrecision(5, 2);

        }
    }
}
