using ReqTracking.Backend.Enums;

namespace ReqTracking.Backend.Dtos;

public class ChangeStageDto
{
    public int Id { get; set; }
    public Stage Stage { get; set; }
}