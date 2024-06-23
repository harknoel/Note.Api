using Microsoft.EntityFrameworkCore;
using Note.Api.Data;
using Note.Api.Models;
using Note.Api.Models.Request;
using Note.Api.Services.Interface;

namespace Note.Api.Services;

public class EntryService(DataContext context) : IEntryService
{
    public async Task<List<Entry>> GetAllEntries()
    {
        return await context.Entries.ToListAsync();
    }

    public async Task<Entry> CreateEntry(EntryRequest entryRequest)
    {
        Entry entry = new()
        {
            Title = entryRequest.Title,
            Content = entryRequest.Content,
            Category = entryRequest.Category
        };

        context.Entries.Add(entry);
        await context.SaveChangesAsync();
        return entry;
    }

    public async Task<Entry> GetEntryByID(int id)
    {
        return await context.FindItemById<Entry>(id);
    }

    public async Task<Entry> UpdateEntryById(int id, EntryRequest entryRequest)
    {
        Entry? entry = await context.FindItemById<Entry>(id);

        entry.Title = entryRequest.Title;
        entry.Content = entryRequest.Content;
        entry.Category = entryRequest.Category;

        await context.SaveChangesAsync();

        return entry;
    }

    public async Task<Entry> DeleteEntryById(int id)
    {
        Entry entry = await context.FindItemById<Entry>(id);

        context.Entries.Remove(entry);
        await context.SaveChangesAsync();

        return entry;
    }
}