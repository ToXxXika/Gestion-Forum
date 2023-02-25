using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("post_commments")]
public class PostComment

{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required, Column("id_post"), ForeignKey("post")]
    public String post_ref_fk{ get; set; }

    [Required, Column("commentref"), ForeignKey("comments")]
    public string commentref { get; set; } 
    
    public virtual Post post { get; set; }
    public virtual Comments comments { get; set; }
    

}