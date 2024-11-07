using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReqTracking.Backend.Enums;

namespace ReqTracking.Backend.Models;

public class Tracking
{
    [Key]
    public int Id { get; set; }
    public Stage Stage { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(User))]
    public int RequerimentId { get; set; }
    public Requeriment Requeriment { get; set; } = null!;
}