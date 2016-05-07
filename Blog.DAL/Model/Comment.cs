using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Blog.DAL.Model
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Content { get; set; }
        public string Author { get; set; }
        [Required]
        public long PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
