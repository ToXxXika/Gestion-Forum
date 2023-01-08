using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;

[Table("login")]
public class Login
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int idlog { get; set; }
    [Required,EmailAddress]
    [StringLength(255)]
    public string mail { get; set; }
    [Required]
    [StringLength(255)]
    public string pwd { get; set; }
    
}