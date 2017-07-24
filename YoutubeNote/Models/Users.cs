using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace YoutubeNote.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string Url{ get; set; }
        public string TimeStamp { get; set; }
        public string Note { get; set; }
        public string Title { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/users/{0}", this.UsersId);
            }
            set { }
        }
    }
}