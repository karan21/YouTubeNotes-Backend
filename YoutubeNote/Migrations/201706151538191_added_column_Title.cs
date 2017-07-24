namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_column_Title : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Title");
        }
    }
}
