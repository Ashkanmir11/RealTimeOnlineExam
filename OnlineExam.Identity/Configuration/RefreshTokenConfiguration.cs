using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
namespace OnlineExam.Identity.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Token).IsRequired().HasMaxLength(500);
            builder.Property(e => e.ExpireDate).IsRequired();
            builder.Property(e=>e.UserId).IsRequired();
        }
    }
}
