using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReqTracking.Backend.Models;

public class UserLead
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    [ForeignKey(nameof(Lead))]
    public int LeadId { get; set; }
    public User Lead { get; set; } = null!;
}