using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<OnlineExamUser>
    {
        public void Configure(EntityTypeBuilder<OnlineExamUser> builder)
        {
           builder.HasMany(e=>e.RefreshTokens).WithOne(e=>e.User).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
