using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Identity.Configuration;
using OnlineExam.Identity.Model;


namespace OnlineExam.Identity
{
    public class OnlineExamIdentityDbContext : IdentityDbContext<OnlineExamUser>
    {
        public OnlineExamIdentityDbContext(DbContextOptions<OnlineExamIdentityDbContext> options) : base(options)
        {

        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
