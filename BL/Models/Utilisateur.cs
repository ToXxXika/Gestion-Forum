using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("utilisateur")]
public class Utilisateur
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Required]
    [Column("utilisateur_id")]
    public int utilisateur_id { get; set; }
    [Required]
    [StringLength(50)]
    [Column("nom")]
    public string nom { get; set; }
    [Required]
    [StringLength(50)]
    [Column("prenom")]
    public string prenom { get; set; }
    [Required]
    [StringLength(50)]
    [Column("mail")]
    public string mail { get; set; }
    [Required]
    [StringLength(50)]
    [Column("pwd")]
    public string pwd { get; set; }
    [Required]
    [MinLength(255),ForeignKey("role")]
    [Column("role")]
    public string role { get; set; }
    [Required]
    [StringLength(50)]
    [Column("adresse")]
    public string adresse {get; set;}
    [Required]
    [StringLength(50)]
    [Column("username")]
    public string username { get; set; }
    [Required]
    [StringLength(50)]
    [Column("phone")]
    public string phone { get; set;  }
    
    public virtual Role roles { get; set; }
    public virtual ICollection<Comments> Comments { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}