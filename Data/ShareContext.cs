using Microsoft.EntityFrameworkCore;
using XKnows.Models;

namespace XKnows.Data
{
    public class ShareContext : DbContext
    {
        public ShareContext (DbContextOptions<ShareContext> options)
            : base(options)
        {
        }

        public DbSet<Share> Share { get; set; }
    }
}