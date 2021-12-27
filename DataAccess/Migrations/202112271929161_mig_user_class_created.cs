namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_class_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Admins", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
            CreateIndex("dbo.Admins", "UserId");
            CreateIndex("dbo.Writers", "UserId");
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Writers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Admins", "UserName");
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Writers", "FirstName");
            DropColumn("dbo.Writers", "LastName");
            DropColumn("dbo.Writers", "Email");
            DropColumn("dbo.Writers", "Password");
            DropColumn("dbo.Writers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "Password", c => c.String(maxLength: 200));
            AddColumn("dbo.Writers", "Email", c => c.String(maxLength: 200));
            AddColumn("dbo.Writers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Writers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "Password", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "UserName", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Writers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropIndex("dbo.Writers", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Writers", "UserId");
            DropColumn("dbo.Admins", "UserId");
            DropTable("dbo.Users");
        }
    }
}
