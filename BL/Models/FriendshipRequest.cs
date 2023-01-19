using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models;
[Table("FriendshipRequest")]
public class FriendshipRequest
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id{get;set;}

    [Column("sender_id")]
    [StringLength(255)]
    public int? senderId{get;set;}
    [Column("receiver_id")]
   
    [StringLength(255)]
    public int? receiverId{get;set;}
    [Column("status")]
    [StringLength(255)]
    [DefaultValue("pending")]
    public string status{get;set;}
   
    [ForeignKey("senderId")]
    public virtual Utilisateur sender{get;set;}
    [ForeignKey("receiverId")]
    public virtual Utilisateur receiver{get;set;}
    
}