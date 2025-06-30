using MyBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MayBlog.Application.Abstrakctions
{
    public interface IApplictionDbContext
    {
        public DbSet<Post> Posts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
