namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Url", c => c.String());
            AddColumn("dbo.Users", "TimeStamp", c => c.String());
            AddColumn("dbo.Users", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Note");
            DropColumn("dbo.Users", "TimeStamp");
            DropColumn("dbo.Users", "Url");
        }
    }
}
