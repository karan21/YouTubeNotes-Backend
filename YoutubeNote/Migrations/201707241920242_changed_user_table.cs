namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_user_table : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AnnotationId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Permissions", c => c.String());
            AlterColumn("dbo.Users", "Url", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", new[] { "Email", "Url" });
            DropColumn("dbo.Users", "UsersId");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "TimeStamp");
            DropColumn("dbo.Users", "Note");
            DropColumn("dbo.Users", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Title", c => c.String());
            AddColumn("dbo.Users", "Note", c => c.String());
            AddColumn("dbo.Users", "TimeStamp", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "UsersId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Url", c => c.String());
            DropColumn("dbo.Users", "Permissions");
            DropColumn("dbo.Users", "AnnotationId");
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Users", "Email");
            AddPrimaryKey("dbo.Users", "UsersId");
        }
    }
}
