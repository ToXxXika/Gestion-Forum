using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("reaction_post")]
public class Reaction_Post
{
    [Required,Column("idpostref"),Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idpostref { get; set; }
    [Required,Column("reaction_ref_pk"),ForeignKey("reaction"),MaxLength(255)]
    public String reaction_ref_pk { get; set; }
    [Required,Column("post_ref_pk"),ForeignKey("post"),MaxLength(255)]
    public String post_ref_pk { get; set; }
    [Required,Column("reaction_count")]
    public int reaction_count { get; set; }
    public virtual Reaction reaction { get; set; }
    public virtual Post post { get; set; }

}