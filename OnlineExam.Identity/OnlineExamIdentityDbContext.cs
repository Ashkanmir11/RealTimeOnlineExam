using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace OnlineExam.Identity
{
    public class OnlineExamIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public OnlineExamIdentityDbContext(DbContextOptions<OnlineExamIdentityDbContext> options) : base(options)
        {

        }
    }
}
