using Note.Api.Models;
using Note.Api.Models.Interface;
using Note.Api.Models.Request;

namespace Note.Api.Services.Interface;
public interface IEntryService
{
    public Task<List<Entry>> GetAllEntries();

    public Task<Entry> CreateEntry(EntryRequest entryRequest);

    public Task<Entry> GetEntryByID(int id);

    public Task<Entry> UpdateEntryById(int id, EntryRequest entryRequest);

    public Task<Entry> DeleteEntryById(int id);
}