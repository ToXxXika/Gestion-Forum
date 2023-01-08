using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("reaction_comment")]
public class ReactionComment
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("reaction_ref")]
    public int reaction_ref { get; set; }
    [Required,Column("comment_ref_pk"),MinLength(255),ForeignKey("comment")]
    public String comment_ref_pk { get; set; }
    [Required,Column("reaction_ref_pk"),MinLength(255),ForeignKey("reaction")]
    public String reaction_ref_pk { get; set; }
    [Required,Column("reaction_count")] 
    public int reaction_count { get; set; }
    
    public virtual Comments comment { get; set; }
    public virtual Reaction reaction { get; set; }
}