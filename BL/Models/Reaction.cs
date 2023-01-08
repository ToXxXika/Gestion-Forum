using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("reaction")]
public class Reaction
{
    [Key, Column("reaction_ref"), MinLength(255)]
    public String reaction_ref { get; set; }
    [Column("reaction_type"),MinLength(255)]
    public String reaction_type { get; set; }
    [Column("reaction_description"),MinLength(255)]
    public String reaction_description { get; set; }
    
}