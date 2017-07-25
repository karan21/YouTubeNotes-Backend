namespace YoutubeNote.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YoutubeNote.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<YoutubeNote.Models.YoutubeNoteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YoutubeNote.Models.YoutubeNoteContext context)
        {
            
            /*context.Users.AddOrUpdate(p => p.UsersId,
               new Users
               {
                   Email = "Karan",
                   Url = "url1",
                   TimeStamp = "05:00",
                   Note = "Note1",
                   Title = "Title1"
                   
               },
               new Users
               {
                   Email = "Karan",
                   Url = "url1",
                   TimeStamp = "05:22",
                   Note = "Note2",
                   Title = "Title1"

               },
               new Users
               {
                   Email = "Karan",
                   Url = "url2",
                   TimeStamp = "05:00",
                   Note = "Note3",
                   Title = "Title2"

               },
               new Users
               {
                   Email = "Viplav",
                   Url = "url1",
                   TimeStamp = "05:22",
                   Note = "Note4",
                   Title = "Title1"

               }
                );*/
        }
    }
}
