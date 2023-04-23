using System.ComponentModel.DataAnnotations;

namespace OptionsPatternDemo;

public class WeatherOptions
{
    [Required(AllowEmptyStrings = false)]
    public string? City { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string? State { get; set; }
    [Range(0, 100)]
    public int? Temperature { get; set; } = null;
    public string? Summary { get; set; }
}
