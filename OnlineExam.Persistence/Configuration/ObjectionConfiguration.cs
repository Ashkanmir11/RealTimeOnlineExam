using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class ObjectionConfiguration : IEntityTypeConfiguration<Objection>
    {
        public void Configure(EntityTypeBuilder<Objection> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.TeacherComment).HasMaxLength(1000);
            builder.Property(e => e.StudentText).IsRequired().HasMaxLength(1000);

        }
    }
}
