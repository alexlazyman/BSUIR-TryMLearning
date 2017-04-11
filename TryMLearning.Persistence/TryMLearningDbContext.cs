using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TryMLearning.Persistence.Constants;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence
{
    public class TryMLearningDbContext : DbContext
    {
        public TryMLearningDbContext()
            : base(DatabaseNames.TryMLearning)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<AlgorithmDbEntity> Algorithms { get; set; }

        public DbSet<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }

        public DbSet<AlgorithmSessionDbEntity> AlgorithmSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmSession)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmParameter)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}