namespace Tareass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "User_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "User_Id" });
            RenameColumn(table: "dbo.Tasks", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Tasks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "UserId");
            AddForeignKey("dbo.Tasks", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            AlterColumn("dbo.Tasks", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Tasks", "User_Id");
            AddForeignKey("dbo.Tasks", "User_Id", "dbo.Users", "Id");
        }
    }
}
