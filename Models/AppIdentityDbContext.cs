using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Indo_Burma.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        //I honestly don't know what this is doing
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}