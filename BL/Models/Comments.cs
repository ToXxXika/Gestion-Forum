using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("comments")]
public class Comments
{
    [Key,MinLength(50),Column("comment_reference")]
    public String comment_reference { get; set; }
    [Required,MinLength(250),Column("comment_content")]
    public String comment_content { get; set; }
    //this column is a foreign key from the users table
    [Required,ForeignKey("utilisateur"),Editable(false)]
    public int comment_user { get; set;}

    public virtual Utilisateur utilisateur { get; set; }
}