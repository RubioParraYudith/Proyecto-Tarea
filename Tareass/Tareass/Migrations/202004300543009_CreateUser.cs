namespace Tareass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tasks", "User_Id", c => c.Int());
            AlterColumn("dbo.Tasks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "EndDate", c => c.DateTime());
            CreateIndex("dbo.Tasks", "User_Id");
            AddForeignKey("dbo.Tasks", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Tasks", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "User", c => c.String());
            DropForeignKey("dbo.Tasks", "User_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Id" });
            AlterColumn("dbo.Tasks", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
