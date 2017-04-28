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
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId, cascadeDelete: true)
                .Index(t => t.AlgorithmId);
            
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
                .ForeignKey("dbo.AlgorithmParameter", t => t.AlgorithmParameterId)
                .ForeignKey("dbo.AlgorithmEstimate", t => t.AlgorithmEstimateId)
                .Index(t => t.AlgorithmParameterId)
                .Index(t => t.AlgorithmEstimateId);
            
            CreateTable(
                "dbo.AlgorithmEstimate",
                c => new
                    {
                        AlgorithmEstimateId = c.Int(nullable: false, identity: true),
                        AlgorithmId = c.Int(nullable: false),
                        DataSetId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlgorithmEstimateId)
                .ForeignKey("dbo.Algorithm", t => t.AlgorithmId, cascadeDelete: true)
                .ForeignKey("dbo.DataSet", t => t.DataSetId, cascadeDelete: true)
                .Index(t => t.AlgorithmId)
                .Index(t => t.DataSetId);
            
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
                "dbo.ClassificationDataSetSample",
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
                        ClassificationDataSetSampleId = c.Int(),
                    })
                .PrimaryKey(t => t.DoubleTupleId)
                .ForeignKey("dbo.ClassificationDataSetSample", t => t.ClassificationDataSetSampleId)
                .Index(t => t.ClassificationDataSetSampleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoubleTuple", "ClassificationDataSetSampleId", "dbo.ClassificationDataSetSample");
            DropForeignKey("dbo.ClassificationDataSetSample", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmEstimateId", "dbo.AlgorithmEstimate");
            DropForeignKey("dbo.AlgorithmEstimate", "DataSetId", "dbo.DataSet");
            DropForeignKey("dbo.AlgorithmEstimate", "AlgorithmId", "dbo.Algorithm");
            DropForeignKey("dbo.AlgorithmParameterValue", "AlgorithmParameterId", "dbo.AlgorithmParameter");
            DropForeignKey("dbo.AlgorithmParameter", "AlgorithmId", "dbo.Algorithm");
            DropIndex("dbo.DoubleTuple", new[] { "ClassificationDataSetSampleId" });
            DropIndex("dbo.ClassificationDataSetSample", new[] { "DataSetId" });
            DropIndex("dbo.AlgorithmEstimate", new[] { "DataSetId" });
            DropIndex("dbo.AlgorithmEstimate", new[] { "AlgorithmId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmEstimateId" });
            DropIndex("dbo.AlgorithmParameterValue", new[] { "AlgorithmParameterId" });
            DropIndex("dbo.Algorithm", new[] { "Alias" });
            DropIndex("dbo.AlgorithmParameter", new[] { "AlgorithmId" });
            DropTable("dbo.DoubleTuple");
            DropTable("dbo.ClassificationDataSetSample");
            DropTable("dbo.DataSet");
            DropTable("dbo.AlgorithmEstimate");
            DropTable("dbo.AlgorithmParameterValue");
            DropTable("dbo.Algorithm");
            DropTable("dbo.AlgorithmParameter");
        }
    }
}
