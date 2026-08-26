using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class TrueOrFalseAnswersConfiguration : IEntityTypeConfiguration<TrueOrFalseAnswers>
    {
        public void Configure(EntityTypeBuilder<TrueOrFalseAnswers> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.StudentScore).HasPrecision(5, 2);

        }
    }
}
