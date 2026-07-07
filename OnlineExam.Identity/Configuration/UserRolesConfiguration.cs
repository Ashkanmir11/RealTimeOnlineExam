using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Identity.Model;
namespace OnlineExam.Identity.Configuration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasData(new IdentityUserRole<string>()
            {
                RoleId = "3d2d9895-7c3f-4de8-acde-19c296c5e401",
                UserId = "017d4854-86f0-4e95-ba1d-3c5e0f9be6be"
            });
        }
    }


}
