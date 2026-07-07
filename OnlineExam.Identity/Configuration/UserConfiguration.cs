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
            var admin = new OnlineExamUser()
            {
                Id = "017d4854-86f0-4e95-ba1d-3c5e0f9be6be",
                UserName = "AshkanTest",
                Email = "ashkan110mir@gmail.com",
                FirstName = "Ashkan",
                LastName = "Mr",
                NationalCode = 1111111111,
                EmailConfirmed = true,
                PhoneNumber = "09908752252",
                PhoneNumberConfirmed = true,
                
            };
            var hasher = new PasswordHasher<OnlineExamUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "Ashkanpass12!");

            builder.HasData(admin);

        }
    }
}
