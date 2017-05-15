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
        }

        public DbSet<AlgorithmDbEntity> Algorithms { get; set; }

        public DbSet<AlgorithmParameterDbEntity> AlgorithmParameters { get; set; }

        public DbSet<AlgorithmParameterValueDbEntity> AlgorithmParameterValues { get; set; }

        public DbSet<AlgorithmEstimationDbEntity> AlgorithmEstimations { get; set; }

        public DbSet<DataSetDbEntity> DataSets { get; set; }

        public DbSet<ClassificationSampleDbEntity> ClassificationDataSamples { get; set; }

        public DbSet<ClassificationResultDbEntity> ClassificationResults { get; set; }

        public DbSet<AlgorithmEstimatorDbEntity> AlgorithmEstimators { get; set; }

        public DbSet<DoubleTupleDbEntity> DoubleTuples { get; set; }

        public DbSet<UserDbEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<AlgorithmParameterValueDbEntity>()
                .HasRequired(v => v.AlgorithmEstimation)
                .WithMany(s => s.AlgorithmParameterValues)
                .HasForeignKey(v => v.AlgorithmEstimationId)
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
                    c.ToTable("ClassificationSampleDoubleTuple", "rel");
                    c.MapLeftKey("SampleId");
                    c.MapRightKey("TupleId");
                });

            modelBuilder.Entity<DataSetDbEntity>()
                .HasRequired(e => e.Author)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}