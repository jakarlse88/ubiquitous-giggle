using Microsoft.EntityFrameworkCore;
using MTK.RankAPI.Models;

namespace MTK.RankAPI.Data
{
    public class RankServiceDbContext : DbContext
    {
        public RankServiceDbContext(DbContextOptions<RankServiceDbContext> options) : base(options)
        {
        }

        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<RankType> RankType { get; set; }

    }
}