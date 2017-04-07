using System.Data.Entity;
using TryMLearning.Persistence.Constants;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence
{
    public class TryMLearningDbContext : DbContext
    {
        public TryMLearningDbContext()
            : base(DatabaseNames.TryMLearning)
        {
        }

        public DbSet<AlgorithmDbEntity> Algorithms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}