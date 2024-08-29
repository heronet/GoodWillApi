namespace GoodWillApi.Data.DTO;

public class LogItem
{
    public required string Place { get; set; }
    public int Count { get; set; }
    public required string Type { get; set; }
    public string? Incident { get; set; }
}
