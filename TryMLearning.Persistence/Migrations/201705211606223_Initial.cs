namespace TryMLearning.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId)
                .Index(t => t.AlgorithmId);
            
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
                        EstimationId = c.Int(nullable: false),
                        IntVal = c.Int(),
                        DoubleVal = c.Double(),
                        StringVal = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.AlgorithmParameterValueId)
                .ForeignKey("dbo.AlgorithmParameter", t => t.AlgorithmParameterId)
                .ForeignKey("dbo.Estimation", t => t.EstimationId, cascadeDelete: true)
                .Index(t => t.AlgorithmParameterId)
                .Index(t => t.EstimationId);
            
            CreateTable(
                "dbo.Estimation",
                c => new
                    {
                        EstimationId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Access = c.Int(nullable: false),
                        AlgorithmId = c.Int(nullable: false),
                        DataSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstimationId)
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId)
                .ForeignKey("dbo.DataSet", t => t.DataSetId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AlgorithmId)
                .Index(t => t.DataSetId);
            
            CreateTable(
                "dbo.ClassificationResult",
                c => new
                    {
                        ClassificationResultId = c.Int(nullable: false, identity: true),
                        EstimationId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        ExpectedClass = c.Int(nullable: false),
                        ActualClass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationResultId)
                .ForeignKey("dbo.Estimation", t => t.EstimationId, cascadeDelete: true)
                .Index(t => t.EstimationId);
            
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
                "dbo.ClassAlias",
                c => new
                    {
                        DataSetId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Alias = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.DataSetId, t.ClassId })
                .ForeignKey("dbo.DataSet", t => t.DataSetId)
                .Index(t => new { t.DataSetId, t.ClassId }, unique: true, name: "DataSetAndClass");
            
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
                .ForeignKey("dbo.DataSet", t => t.DataSetId)
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
                "rel.ClassificationSampleDoubleTuple",
                c => new
                    {
                        SampleId = c.Int(nullable: false),
                        TupleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SampleId, t.TupleId })
                .ForeignKey("dbo.ClassificationSample", t => t.SampleId)
                .ForeignKey("dbo.DoubleTuple", t => t.TupleId)
                .Index(t => t.SampleId)
                .Index(t => t.TupleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "TupleId", "dbo.DoubleTuple");
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "SampleId", "dbo.ClassificationSample");
            DropForeignKey("dbo.ClassificationSample", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.Estimation", "UserId", "dbo.User");
            DropForeignKey("dbo.Estimation", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.ClassAlias", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.DataSet", "AuthorId", "dbo.User");
            DropForeignKey("dbo.ClassificationResult", "EstimationId", "dbo.Estimation");
            DropForeignKey("dbo.AlgorithmParameterValue", "EstimationId", "dbo.Estimation");
            DropForeignKey("dbo.Estimation", "AlgorithmId", "dbo.Algorithm");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmParameterId", "dbo.AlgorithmParameter");
            DropForeignKey("dbo.Algorithm", "AuthorId", "dbo.User");
            DropForeignKey("dbo.AlgorithmParameter", "AlgorithmId", "dbo.Algorithm");
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "TupleId" });
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "SampleId" });
            DropIndex("dbo.ClassificationSample", new[] { "DataSetId" });
            DropIndex("dbo.ClassAlias", "DataSetAndClass");
            DropIndex("dbo.DataSet", new[] { "AuthorId" });
            DropIndex("dbo.ClassificationResult", new[] { "EstimationId" });
            DropIndex("dbo.Estimation", new[] { "DataSetId" });
            DropIndex("dbo.Estimation", new[] { "AlgorithmId" });
            DropIndex("dbo.Estimation", new[] { "UserId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "EstimationId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmParameterId" });
            DropIndex("dbo.Algorithm", new[] { "Alias" });
            DropIndex("dbo.Algorithm", new[] { "AuthorId" });
            DropIndex("dbo.AlgorithmParameter", new[] { "AlgorithmId" });
            DropTable("rel.ClassificationSampleDoubleTuple");
            DropTable("dbo.DoubleTuple");
            DropTable("dbo.ClassificationSample");
            DropTable("dbo.ClassAlias");
            DropTable("dbo.DataSet");
            DropTable("dbo.ClassificationResult");
            DropTable("dbo.Estimation");
            DropTable("dbo.AlgorithmParameterValue");
            DropTable("dbo.User");
            DropTable("dbo.Algorithm");
            DropTable("dbo.AlgorithmParameter");
        }
    }
}
