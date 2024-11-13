using ReqTracking.Backend.Enums;

namespace ReqTracking.Backend.Dtos;

public class RequerimentFilterDto
{
    public int? Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public Stage Stage { get; set; }
    public Priority Priority { get; set; }
}