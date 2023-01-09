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

    [Required, Column("id_utilisateur"), ForeignKey("utilisateur")]
    public int utilisateur_fk { get; set; } 
    
    public virtual Post post { get; set; }
    public virtual Utilisateur utilisateur { get; set; }
    

}