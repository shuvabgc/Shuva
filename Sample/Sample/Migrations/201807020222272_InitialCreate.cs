namespace Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        BankCode = c.String(),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        SwiftCode = c.String(),
                        BankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Jn_Employee",
                c => new
                    {
                        Empid = c.Long(nullable: false, identity: true),
                        Empname = c.String(),
                        Empaddress = c.String(),
                        Empsalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Empemail = c.String(),
                        Empdateofbirth = c.DateTime(nullable: false),
                        DesignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Empid)
                .ForeignKey("dbo.Jn_DesignationByEmployee", t => t.DesignId, cascadeDelete: true)
                .Index(t => t.DesignId);
            
            CreateTable(
                "dbo.Jn_DesignationByEmployee",
                c => new
                    {
                        DesignId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jn_Employee", "DesignId", "dbo.Jn_DesignationByEmployee");
            DropForeignKey("dbo.Branches", "BankId", "dbo.Banks");
            DropIndex("dbo.Jn_Employee", new[] { "DesignId" });
            DropIndex("dbo.Branches", new[] { "BankId" });
            DropTable("dbo.Jn_DesignationByEmployee");
            DropTable("dbo.Jn_Employee");
            DropTable("dbo.Branches");
            DropTable("dbo.Banks");
        }
    }
}
