namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_annotation_table1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
        }
    }
}
