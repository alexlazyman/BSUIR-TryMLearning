using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TryMLearning.Persistence.Constants;
using TryMLearning.Persistence.Models;
using TryMLearning.Persistence.Models.Map;

namespace TryMLearning.Persistence
{
    public class TryMLearningDbContext : DbContext
    {
        public TryMLearningDbContext()
            : base(DatabaseNames.TryMLearning)
        {
            Database.SetInitializer(new TryMLearningDbContextInitializer());
        }

        public DbSet<AlgorithmDbEntity> Algorithms { get; set; }

        public DbSet<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }

        public DbSet<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }

        public DbSet<AlgorithmSessionDbEntity> AlgorithmSessions { get; set; }

        public DbSet<DataSetDbEntity> DataSets { get; set; }

        public DbSet<ClassificationDataSetSmapleDbEntity> ClassificationDataSmaples { get; set; }

        public DbSet<DoubleTupleDbEntity> DoubleTuples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmSession)
                .WithMany(s => s.AlgorithmParameterValues)
                .HasForeignKey(v => v.AlgorithmSessionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmParameter)
                .WithMany()
                .HasForeignKey(v => v.AlgorithmParameterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassificationDataSetSmapleDoubleTupleMap>()
                .HasRequired(m => m.DoubleTuple)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(true);
        }
    }
}