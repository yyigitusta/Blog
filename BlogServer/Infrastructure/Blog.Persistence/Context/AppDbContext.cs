using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
      public DbSet<Category> Categories { get; set; }
      public DbSet<eBlog> eBlogs { get; set; }
      public DbSet<Social> Socials { get; set; }
      public DbSet<Message> Messages { get; set; }
      public DbSet<ContacInfo> ContacInfos { get; set; }  
    }
}
