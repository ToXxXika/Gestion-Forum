using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("post")]
public class Post
{
    [Key,Required,MaxLength(255)]
    public String post_ref { get; set; }
    [Required,MaxLength(255)]
    public String post_title { get; set; }
    [Required,MaxLength(255)]
    public String post_content { get; set; }
    [Required,MaxLength(255)]
    public String post_subtitle { get; set; }
    [Required,MaxLength(255),ForeignKey("blog")]
    public String blog_ref { get; set; }
  
    public virtual Blog blog { get; set; }
}