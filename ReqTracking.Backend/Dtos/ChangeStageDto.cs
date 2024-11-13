using ReqTracking.Backend.Enums;

namespace ReqTracking.Backend.Dtos;

public class ChangeStageDto
{
    public int IdRequeriment { get; set; }
    public int IdUser { get; set; }
    public Stage Stage { get; set; }
    public string Description { get; set; } = string.Empty;
}