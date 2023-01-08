using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("blog")]
public class Blog
{
    [Key]
    [StringLength(255)]
    [Column("blog_reference")]
    public string blog_reference { get; set; }
    [StringLength(255)]
    [Column("blog_title")]
    public string blog_title { get; set; }
      
    public virtual ICollection<Post> Posts { get; set; }
}