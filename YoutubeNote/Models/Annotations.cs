using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YoutubeNote.Models
{
    public class Annotations
    {
        [Key]
        public int AnnotationId { get; set; }
        public String timestamp { get; set; }
        public String message { get; set; }
        
        public virtual Users AntId { get; set; }
    }
}