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
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;

            Database.SetInitializer(new TryMLearningDbContextInitializer());
        }

        public DbSet<AlgorithmDbEntity> Algorithms { get; set; }

        public DbSet<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }

        public DbSet<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }

        public DbSet<AlgorithmEstimateDbEntity> AlgorithmEstimates { get; set; }

        public DbSet<DataSetDbEntity> DataSets { get; set; }

        public DbSet<ClassificationSampleDbEntity> ClassificationDataSamples { get; set; }

        public DbSet<DoubleTupleDbEntity> DoubleTuples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmEstimate)
                .WithMany(s => s.AlgorithmParameterValues)
                .HasForeignKey(v => v.AlgorithmEstimateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmParameter)
                .WithMany()
                .HasForeignKey(v => v.AlgorithmParameterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassificationSampleDbEntity>()
                .HasMany(m => m.FeatureTuples)
                .WithMany()
                .Map(c =>
                {
                    c.ToTable("ClassificationSampleDoubleTuple");
                    c.MapLeftKey("SampleId");
                    c.MapRightKey("TupleId");
                });
        }
    }
}