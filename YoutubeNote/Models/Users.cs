using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace YoutubeNote.Models
{
    public class Users

    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int AnnotationId { get; set; }
        [Key, Column(Order = 0)]
        public string Email { get; set; }
        [Key, Column(Order = 1)]
        public string Url{ get; set; }
        public string Permissions { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/users/{0}", this.AnnotationId);
            }
            set { }
        }
    }
}