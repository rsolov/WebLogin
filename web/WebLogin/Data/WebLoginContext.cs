using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebLogin.Models
{
    public class WebLoginContext : DbContext
    {
        public WebLoginContext (DbContextOptions<WebLoginContext> options)
            : base(options)
        {
        }

        public DbSet<WebLogin.Models.User> User { get; set; }
    }
}
