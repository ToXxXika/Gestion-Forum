using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

public class Role
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("role_ref"),MinLength(255),Key]
    public String role_ref { get; set; }
    [Required,MinLength(255)]
    public String role_name { get; set; }
    
}