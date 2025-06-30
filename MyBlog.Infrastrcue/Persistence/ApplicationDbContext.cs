using MayBlog.Application.Abstrakctions;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;
using System.Data.Common;

namespace MyBlog.Infrastrcue.Persistence
{
    public class ApplicationDbContext : DbContext, IApplictionDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
