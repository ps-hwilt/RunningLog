namespace RunningLog.Models;

public record Activity
{
    public Guid Id { get; set; }
    
    public string? Time { get; set; }
    
    public decimal Distance { get; set; }
    
    public DateTime StartTime { get; set; }
    
}