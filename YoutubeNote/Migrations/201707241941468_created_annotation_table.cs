namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_annotation_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annotations",
                c => new
                    {
                        AnnotationId = c.Int(nullable: false, identity: true),
                        timestamp = c.String(),
                        message = c.String(),
                        AntId_Email = c.String(maxLength: 128),
                        AntId_Url = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnnotationId)
                .ForeignKey("dbo.Users", t => new { t.AntId_Email, t.AntId_Url })
                .Index(t => new { t.AntId_Email, t.AntId_Url });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Annotations", new[] { "AntId_Email", "AntId_Url" }, "dbo.Users");
            DropIndex("dbo.Annotations", new[] { "AntId_Email", "AntId_Url" });
            DropTable("dbo.Annotations");
        }
    }
}
