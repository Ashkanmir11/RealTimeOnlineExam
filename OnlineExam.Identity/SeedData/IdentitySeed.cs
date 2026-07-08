using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace OnlineExam.Identity.SeedData
{
    public class IdentitySeed
    {
        public IdentitySeed()
        {
        }
        public static async Task<bool> Seed(IServiceProvider serviceProvider)
        {
            var userManagerService = serviceProvider.GetService<UserManager<OnlineExamUser>>();
            var roleManagerService = serviceProvider.GetService<RoleManager<IdentityRole>>();

            #region Seed Role
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name="Admin",
                },
                new IdentityRole()
                {
                    Name="user"
                }
            };
            foreach (var role in roles)
            {
                if (await roleManagerService.FindByNameAsync(role.Name) == null)
                {
                    await roleManagerService.CreateAsync(role);
                }
            }
            #endregion

            #region Seed User 
            var users = new List<OnlineExamUser>()
            {
                new OnlineExamUser()
                {
                UserName = "AshkanTest",
                Email = "ashkan110mir@gmail.com",
                FirstName = "Ashkan",
                LastName = "Mr",
                NationalCode = 1111111111,
                EmailConfirmed = true,
                PhoneNumber = "09908752252",
                PhoneNumberConfirmed = true,
                }
            };
            foreach (var user in users)
            {
                if (await userManagerService.FindByEmailAsync(user.Email) == null)
                {
                    var userCreateResult = await userManagerService.CreateAsync(user, "Ashkanpass12!");
                    if (userCreateResult.Succeeded)
                    {
                        var userCreated = await userManagerService.FindByNameAsync("AshkanTest");
                        await userManagerService.AddToRoleAsync(user, "Admin");
                    }
                }
            }
            #endregion
            return true;
        }
    }
}
