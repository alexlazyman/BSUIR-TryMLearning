namespace TryMLearning.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlgorithmEstimate",
                c => new
                    {
                        AlgorithmEstimateId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        AlgorithmId = c.Int(nullable: false),
                        DataSetId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlgorithmEstimateId)
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId, cascadeDelete: true)
                .ForeignKey("dbo.DataSet", t => t.DataSetId, cascadeDelete: true)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.AlgorithmId)
                .Index(t => t.DataSetId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Algorithm",
                c => new
                    {
                        AlgorithmId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Alias = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AlgorithmId)
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
                "dbo.AlgorithmParameterValue",
                c => new
                    {
                        AlgorithmParameterValueId = c.Int(nullable: false, identity: true),
                        AlgorithmParameterId = c.Int(nullable: false),
                        AlgorithmEstimateId = c.Int(nullable: false),
                        IntVal = c.Int(),
                        DoubleVal = c.Double(),
                        StringVal = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.AlgorithmParameterValueId)
                .ForeignKey("dbo.AlgorithmEstimate", t => t.AlgorithmEstimateId)
                .ForeignKey("dbo.AlgorithmParameter", t => t.AlgorithmParameterId)
                .Index(t => t.AlgorithmParameterId)
                .Index(t => t.AlgorithmEstimateId);
            
            CreateTable(
                "dbo.DataSet",
                c => new
                    {
                        DataSetId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DataSetId);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Alias = c.String(maxLength: 128),
                        Name = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.TestId)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "dbo.BoolTuple",
                c => new
                    {
                        DoubleTupleId = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Value0 = c.Boolean(),
                        Value1 = c.Boolean(),
                        Value2 = c.Boolean(),
                        Value3 = c.Boolean(),
                        Value4 = c.Boolean(),
                        Value5 = c.Boolean(),
                        Value6 = c.Boolean(),
                        Value7 = c.Boolean(),
                        Value8 = c.Boolean(),
                        Value9 = c.Boolean(),
                        Value10 = c.Boolean(),
                        Value11 = c.Boolean(),
                        Value12 = c.Boolean(),
                        Value13 = c.Boolean(),
                        Value14 = c.Boolean(),
                        Value15 = c.Boolean(),
                        Value16 = c.Boolean(),
                        Value17 = c.Boolean(),
                        Value18 = c.Boolean(),
                        Value19 = c.Boolean(),
                        Value20 = c.Boolean(),
                        Value21 = c.Boolean(),
                        Value22 = c.Boolean(),
                        Value23 = c.Boolean(),
                        Value24 = c.Boolean(),
                        Value25 = c.Boolean(),
                        Value26 = c.Boolean(),
                        Value27 = c.Boolean(),
                        Value28 = c.Boolean(),
                        Value29 = c.Boolean(),
                        Value30 = c.Boolean(),
                        Value31 = c.Boolean(),
                        Value32 = c.Boolean(),
                        Value33 = c.Boolean(),
                        Value34 = c.Boolean(),
                        Value35 = c.Boolean(),
                        Value36 = c.Boolean(),
                        Value37 = c.Boolean(),
                        Value38 = c.Boolean(),
                        Value39 = c.Boolean(),
                        Value40 = c.Boolean(),
                        Value41 = c.Boolean(),
                        Value42 = c.Boolean(),
                        Value43 = c.Boolean(),
                        Value44 = c.Boolean(),
                        Value45 = c.Boolean(),
                        Value46 = c.Boolean(),
                        Value47 = c.Boolean(),
                        Value48 = c.Boolean(),
                        Value49 = c.Boolean(),
                        Value50 = c.Boolean(),
                        Value51 = c.Boolean(),
                        Value52 = c.Boolean(),
                        Value53 = c.Boolean(),
                        Value54 = c.Boolean(),
                        Value55 = c.Boolean(),
                        Value56 = c.Boolean(),
                        Value57 = c.Boolean(),
                        Value58 = c.Boolean(),
                        Value59 = c.Boolean(),
                        Value60 = c.Boolean(),
                        Value61 = c.Boolean(),
                        Value62 = c.Boolean(),
                        Value63 = c.Boolean(),
                    })
                .PrimaryKey(t => t.DoubleTupleId);
            
            CreateTable(
                "dbo.ClassificationSample",
                c => new
                    {
                        ClassificationDataSetSampleId = c.Int(nullable: false, identity: true),
                        DataSetId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationDataSetSampleId)
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
                        AlgorithmEstimateId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassificationResultId)
                .ForeignKey("dbo.AlgorithmEstimate", t => t.AlgorithmEstimateId, cascadeDelete: true)
                .Index(t => t.AlgorithmEstimateId);
            
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
            
            CreateTable(
                "rel.ClassificationResultBoolTuple",
                c => new
                    {
                        ResultId = c.Int(nullable: false),
                        TupleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResultId, t.TupleId })
                .ForeignKey("dbo.ClassificationResult", t => t.ResultId, cascadeDelete: true)
                .ForeignKey("dbo.BoolTuple", t => t.TupleId, cascadeDelete: true)
                .Index(t => t.ResultId)
                .Index(t => t.TupleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("rel.ClassificationResultBoolTuple", "TupleId", "dbo.BoolTuple");
            DropForeignKey("rel.ClassificationResultBoolTuple", "ResultId", "dbo.ClassificationResult");
            DropForeignKey("dbo.ClassificationResult", "AlgorithmEstimateId", "dbo.AlgorithmEstimate");
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "TupleId", "dbo.DoubleTuple");
            DropForeignKey("rel.ClassificationSampleDoubleTuple", "SampleId", "dbo.ClassificationSample");
            DropForeignKey("dbo.ClassificationSample", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.AlgorithmEstimate", "TestId", "dbo.Test");
            DropForeignKey("dbo.AlgorithmEstimate", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmParameterId", "dbo.AlgorithmParameter");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmEstimateId", "dbo.AlgorithmEstimate");
            DropForeignKey("dbo.AlgorithmEstimate", "AlgorithmId", "dbo.Algorithm");
            DropForeignKey("dbo.AlgorithmParameter", "AlgorithmId", "dbo.Algorithm");
            DropIndex("rel.ClassificationResultBoolTuple", new[] { "TupleId" });
            DropIndex("rel.ClassificationResultBoolTuple", new[] { "ResultId" });
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "TupleId" });
            DropIndex("rel.ClassificationSampleDoubleTuple", new[] { "SampleId" });
            DropIndex("dbo.ClassificationResult", new[] { "AlgorithmEstimateId" });
            DropIndex("dbo.ClassificationSample", new[] { "DataSetId" });
            DropIndex("dbo.Test", new[] { "Alias" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmEstimateId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmParameterId" });
            DropIndex("dbo.AlgorithmParameter", new[] { "AlgorithmId" });
            DropIndex("dbo.Algorithm", new[] { "Alias" });
            DropIndex("dbo.AlgorithmEstimate", new[] { "TestId" });
            DropIndex("dbo.AlgorithmEstimate", new[] { "DataSetId" });
            DropIndex("dbo.AlgorithmEstimate", new[] { "AlgorithmId" });
            DropTable("rel.ClassificationResultBoolTuple");
            DropTable("rel.ClassificationSampleDoubleTuple");
            DropTable("dbo.ClassificationResult");
            DropTable("dbo.DoubleTuple");
            DropTable("dbo.ClassificationSample");
            DropTable("dbo.BoolTuple");
            DropTable("dbo.Test");
            DropTable("dbo.DataSet");
            DropTable("dbo.AlgorithmParameterValue");
            DropTable("dbo.AlgorithmParameter");
            DropTable("dbo.Algorithm");
            DropTable("dbo.AlgorithmEstimate");
        }
    }
}
