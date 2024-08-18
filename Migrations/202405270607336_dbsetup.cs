namespace iStartWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        EmailID = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.UserRegistrations",
                c => new
                    {
                        RegisterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailID = c.String(),
                        Gender = c.String(),
                        Password = c.String(nullable: false),
                        ReEnterPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRegistrations");
            DropTable("dbo.UserLogins");
        }
    }
}
