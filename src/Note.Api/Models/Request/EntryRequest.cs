namespace Note.Api.Models.Request;

public class EntryRequest
{
    public required string Title { get; set; }

    public required string Content { get; set; }

    public required string Category { get; set; }
}