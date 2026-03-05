using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,string>(options)
    {
      public DbSet<Category> Categories { get; set; }
      public DbSet<eBlog> eBlogs { get; set; }
      public DbSet<Social> Socials { get; set; }
      public DbSet<Message> Messages { get; set; }
      public DbSet<ContacInfo> ContacInfos { get; set; }  
    }
}
