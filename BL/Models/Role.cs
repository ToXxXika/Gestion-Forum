using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("role")]
public class Role
{
    [Column("role_ref"),MaxLength(255),Key]
    public String role_ref { get; set; }
    [Required,MinLength(255)]
    public String role_name { get; set; }
    
    

}