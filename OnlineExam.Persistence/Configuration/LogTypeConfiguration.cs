using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Configuration
{
    public class LogTypeConfiguration : IEntityTypeConfiguration<LogType>
    {
        public void Configure(EntityTypeBuilder<LogType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.HasData(new LogType()
            {
                Id = 1,
                Name = "خروج از صفحه"
            });
            builder.HasData(new LogType()
            {
                Id = 2,
                Name = "تلاش برای کپی و پیست"
            });
        }
    }
}
