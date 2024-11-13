using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReqTracking.Backend.Enums;

namespace ReqTracking.Backend.Models;

public class Requeriment
{
    [Key]
    public int Id { get; set; }
    public string Subject { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Stage Stage { get; set; } = Stage.Pending;
    public Priority Priority { get; set; } = Priority.Low;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    
    [ForeignKey(nameof(UserCreator))]
    public int UserCreatorId { get; set; }
    public User? UserCreator { get; set; }
    
    [ForeignKey(nameof(UserAssigned))]
    public int? UserAssignedId { get; set; }
    public User? UserAssigned { get; set; }
}