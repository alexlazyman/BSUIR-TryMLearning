namespace TryMLearning.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlgorithmEstimation",
                c => new
                    {
                        AlgorithmEstimationId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AlgorithmId = c.Int(nullable: false),
                        DataSetId = c.Int(nullable: false),
                        EstimatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlgorithmEstimationId)
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId, cascadeDelete: true)
                .ForeignKey("dbo.DataSet", t => t.DataSetId, cascadeDelete: true)
                .ForeignKey("dbo.Estimator", t => t.EstimatorId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AlgorithmId)
                .Index(t => t.DataSetId)
                .Index(t => t.EstimatorId);
            
            CreateTable(
                "dbo.Algorithm",
                c => new
                    {
                        AlgorithmId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Alias = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AlgorithmId)
                .ForeignKey("dbo.User", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "dbo.AlgorithmParameter",
                c => new
                    {
                        AlgorithmParameterId = c.Int(nullable: false, identity: true),
                        AlgorithmId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Order = c.Short(nullable: false),
                        ValueType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlgorithmParameterId)
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId, cascadeDelete: true)
                .Index(t => t.AlgorithmId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 128),
                        Email = c.String(maxLength: 128),
                        PasswordHash = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AlgorithmParameterValue",
                c => new
                    {
                        AlgorithmParameterValueId = c.Int(nullable: false, identity: true),
                        AlgorithmParameterId = c.Int(nullable: false),
                        AlgorithmEstimationId = c.Int(nullable: false),
                        IntVal = c.Int(),
                        DoubleVal = c.Double(),
                        StringVal = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.AlgorithmParameterValueId)
                .ForeignKey("dbo.AlgorithmEstimation", t => t.AlgorithmEstimationId)
                .ForeignKey("dbo.AlgorithmParameter", t => t.AlgorithmParameterId)
                .Index(t => t.AlgorithmParameterId)
                .Index(t => t.AlgorithmEstimationId);
            
            CreateTable(
                "dbo.DataSet",
                c => new
                    {
                        DataSetId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DataSetId)
                .ForeignKey("dbo.User", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Estimator",
                c => new
                    {
                        EstimatorId = c.Int(nullable: false, identity: true),
                        Alias = c.String(maxLength: 128),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.EstimatorId)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "dbo.ClassificationSample",
                c => new
                    {
                        ClassificationSampleId = c.Int(nullable: false, identity: true),
                        DataSetId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationSampleId)
                .ForeignKey("dbo.DataSet", t => t.DataSetId, cascadeDelete: true)
                .Index(t => t.DataSetId);
            
            CreateTable(
                "dbo.DoubleTuple",
                c => new
                    {
                        DoubleTupleId = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Value0 = c.Double(),
                        Value1 = c.Double(),
                        Value2 = c.Double(),
                        Value3 = c.Double(),
                        Value4 = c.Double(),
                        Value5 = c.Double(),
                        Value6 = c.Double(),
                        Value7 = c.Double(),
                        Value8 = c.Double(),
                        Value9 = c.Double(),
                        Value10 = c.Double(),
                        Value11 = c.Double(),
                        Value12 = c.Double(),
                        Value13 = c.Double(),
                        Value14 = c.Double(),
                        Value15 = c.Double(),
                        Value16 = c.Double(),
                        Value17 = c.Double(),
                        Value18 = c.Double(),
                        Value19 = c.Double(),
                        Value20 = c.Double(),
                        Value21 = c.Double(),
                        Value22 = c.Double(),
                        Value23 = c.Double(),
                        Value24 = c.Double(),
                        Value25 = c.Double(),
                        Value26 = c.Double(),
                        Value27 = c.Double(),
                        Value28 = c.Double(),
                        Value29 = c.Double(),
                        Value30 = c.Double(),
                        Value31 = c.Double(),
                        Value32 = c.Double(),
                        Value33 = c.Double(),
                        Value34 = c.Double(),
                        Value35 = c.Double(),
                        Value36 = c.Double(),
                        Value37 = c.Double(),
                        Value38 = c.Double(),
                        Value39 = c.Double(),
                        Value40 = c.Double(),
                        Value41 = c.Double(),
                        Value42 = c.Double(),
                        Value43 = c.Double(),
                        Value44 = c.Double(),
                        Value45 = c.Double(),
                        Value46 = c.Double(),
                        Value47 = c.Double(),
                        Value48 = c.Double(),
                        Value49 = c.Double(),
                        Value50 = c.Double(),
                        Value51 = c.Double(),
                        Value52 = c.Double(),
                        Value53 = c.Double(),
                        Value54 = c.Double(),
                        Value55 = c.Double(),
                        Value56 = c.Double(),
                        Value57 = c.Double(),
                        Value58 = c.Double(),
                        Value59 = c.Double(),
                        Value60 = c.Double(),
                        Value61 = c.Double(),
                        Value62 = c.Double(),
                        Value63 = c.Double(),
                    })
                .PrimaryKey(t => t.DoubleTupleId);
            
            CreateTable(
                "dbo.ClassificationResult",
                c => new
                    {
                        ClassificationResultId = c.Int(nullable: false, identity: true),
                        AlgorithmEstimationId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        ExpectedClass = c.Int(nullable: false),
                        ActualClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationResultId)
                .ForeignKey("dbo.AlgorithmEstimation", t => t.AlgorithmEstimationId, cascadeDelete: true)
                .Index(t => t.AlgorithmEstimationId);
            
            CreateTable(
                "rel.ClassificationSampleDoubleTuple",
                c => new
                    {
                        SampleId = c.Int(nullable: false),
                        TupleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SampleId, t.TupleId })
                .ForeignKey("dbo.ClassificationSample", t => t.SampleId, cascadeDelete: true)
                .ForeignKey("dbo.DoubleTuple", t => t.TupleId, cascadeDelete: true)
                .Index(t => t.SampleId)
                .Index(t => t.TupleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassificationResult", "AlgorithmEstimationId", "dbo.AlgorithmEstimation");
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "TupleId", "dbo.DoubleTuple");
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "SampleId", "dbo.ClassificationSample");
            DropForeignKey("dbo.ClassificationSample", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.AlgorithmEstimation", "UserId", "dbo.User");
            DropForeignKey("dbo.AlgorithmEstimation", "EstimatorId", "dbo.Estimator");
            DropForeignKey("dbo.AlgorithmEstimation", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.DataSet", "AuthorId", "dbo.User");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmParameterId", "dbo.AlgorithmParameter");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmEstimationId", "dbo.AlgorithmEstimation");
            DropForeignKey("dbo.AlgorithmEstimation", "AlgorithmId", "dbo.Algorithm");
            DropForeignKey("dbo.Algorithm", "AuthorId", "dbo.User");
            DropForeignKey("dbo.AlgorithmParameter", "AlgorithmId", "dbo.Algorithm");
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "TupleId" });
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "SampleId" });
            DropIndex("dbo.ClassificationResult", new[] { "AlgorithmEstimationId" });
            DropIndex("dbo.ClassificationSample", new[] { "DataSetId" });
            DropIndex("dbo.Estimator", new[] { "Alias" });
            DropIndex("dbo.DataSet", new[] { "AuthorId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmEstimationId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmParameterId" });
            DropIndex("dbo.AlgorithmParameter", new[] { "AlgorithmId" });
            DropIndex("dbo.Algorithm", new[] { "Alias" });
            DropIndex("dbo.Algorithm", new[] { "AuthorId" });
            DropIndex("dbo.AlgorithmEstimation", new[] { "EstimatorId" });
            DropIndex("dbo.AlgorithmEstimation", new[] { "DataSetId" });
            DropIndex("dbo.AlgorithmEstimation", new[] { "AlgorithmId" });
            DropIndex("dbo.AlgorithmEstimation", new[] { "UserId" });
            DropTable("rel.ClassificationSampleDoubleTuple");
            DropTable("dbo.ClassificationResult");
            DropTable("dbo.DoubleTuple");
            DropTable("dbo.ClassificationSample");
            DropTable("dbo.Estimator");
            DropTable("dbo.DataSet");
            DropTable("dbo.AlgorithmParameterValue");
            DropTable("dbo.User");
            DropTable("dbo.AlgorithmParameter");
            DropTable("dbo.Algorithm");
            DropTable("dbo.AlgorithmEstimation");
        }
    }
}
