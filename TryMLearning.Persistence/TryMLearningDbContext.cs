using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
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

        public DbSet<EstimationDbEntity> Estimations { get; set; }

        public DbSet<DataSetDbEntity> DataSets { get; set; }

        public DbSet<ClassificationSampleDbEntity> ClassificationDataSamples { get; set; }

        public DbSet<ClassificationResultDbEntity> ClassificationResults { get; set; }

        public DbSet<DoubleTupleDbEntity> DoubleTuples { get; set; }

        public DbSet<UserDbEntity> Users { get; set; }

        public DbSet<ClassAliasDbEntity> ClassAliases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ClassificationSampleDbEntity>()
                .HasMany(m => m.FeatureTuples)
                .WithMany()
                .Map(c =>
                {
                    c.ToTable("ClassificationSampleDoubleTuple", "rel");
                    c.MapLeftKey("SampleId");
                    c.MapRightKey("TupleId");
                });

            modelBuilder.Entity<EstimationDbEntity>()
                .HasMany(e => e.AlgorithmParameterValues)
                .WithRequired(e => e.Estimation)
                .HasForeignKey(e => e.EstimationId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<EstimationDbEntity>()
                .HasMany(e => e.ClassificationResults)
                .WithRequired(e => e.Estimation)
                .HasForeignKey(e => e.EstimationId)
                .WillCascadeOnDelete(true);
        }
    }
}