using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Identity.Model;


namespace OnlineExam.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<OnlineExamUser>
    {
        public void Configure(EntityTypeBuilder<OnlineExamUser> builder)
        {

            builder.HasMany(e => e.RefreshTokens).WithOne(e => e.User).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.PhoneNumber).IsUnicode(true);
        }
    }
}
