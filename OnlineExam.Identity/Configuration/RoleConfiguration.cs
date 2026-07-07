using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole()
            {
                Id = "3d2d9895-7c3f-4de8-acde-19c296c5e401",
                Name = "Admin"
            });
            builder.HasData(new IdentityRole()
            {
                Id = "06688548-0ef4-4719-83fb-e45a40b2a771",
                Name = "User"
            });
        }
    }
}
