using System.ComponentModel.DataAnnotations;

namespace RunningLog.DTO;

public record UpdateActivityDTO
{
    [Required]
    public string? Time { get; set; }
    
    [Required]
    [Range(0,1000)]
    public decimal Distance { get; set; }
}