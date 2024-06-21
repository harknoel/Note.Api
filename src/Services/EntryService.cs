using Note.Api.Data;
using Note.Api.Models;
using Note.Api.Models.Request;
using Note.Api.Services.Interface;

namespace Note.Api.Services;

public class EntryService(Database database) : IEntryService
{
    private readonly List<Entry> _entries = database.entries;
    public List<Entry> GetAllEntries()
    {
        return _entries;
    }

    public Entry CreateEntry(EntryRequest entryRequest)
    {
        Entry entry = new()
        {
            Id = _entries.Count + 1,
            Title = entryRequest.Title,
            Content = entryRequest.Content,
            Category = entryRequest.Category
        };

        _entries.Add(entry);

        return entry;
    }

    public Entry GetEntryByID(int id)
    {
        return database.FindItemById(_entries, id);
    }

    public Entry UpdateEntryById(int id, EntryRequest entryRequest)
    {
        Entry? entry = database.FindItemById(_entries, id);

        entry.Title = entryRequest.Title;
        entry.Content = entryRequest.Content;
        entry.Category = entryRequest.Category;

        return entry;
    }

    public Entry DeleteEntryById(int id)
    {
        Entry entry = database.FindItemById(_entries, id);

        _entries.Remove(entry);
        return entry;
    }
}