namespace RunningLog.DTO;

public record ActivityDTO
{
    public Guid Id { get; set; }
    
    public string Time { get; set; }
    
    public decimal Distance { get; set; }
    
    public DateTime StartTime { get; set; }
    
}