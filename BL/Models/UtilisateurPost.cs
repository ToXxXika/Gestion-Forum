using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

public class UtilisateurPost
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("id_post_utilisateur")]
    public int id_post_utilisateur { get; set; }
    [Column("utilisateur_id_fk"),ForeignKey("utilisateur")]
    public int utilisateur_id_fk { get; set; }
    [Column("post_ref_fk"),ForeignKey("post"),Required,MinLength(255)]
    public string post_ref_fk { get; set; }
    
    public virtual Utilisateur utilisateur { get; set; }
    public virtual Post post { get; set; }
    
}