using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("permission")]
public class Permission
{
    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idpermission { get; set; }
    [Required,MinLength(50)]
    public String permission_name { get; set; }
    [Required,MinLength(250)]
    public String permission_description { get; set; }
    [Required,MaxLength(30)]
    public String permission_code { get; set; }
    [Required,MinLength(255),ForeignKey("role")]
    public String role_ref { get; set; }
    
    public virtual Role role { get; set; }
    
    

}