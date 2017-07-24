namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Self = c.String(),
                    })
                .PrimaryKey(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
