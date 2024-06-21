using Note.Api.Models;
using Note.Api.Models.Interface;
using Note.Api.Models.Request;

namespace Note.Api.Services.Interface;
public interface IEntryService
{
    public List<Entry> GetAllEntries();

    public Entry CreateEntry(EntryRequest entryRequest);

    public Entry GetEntryByID(int id);

    public Entry UpdateEntryById(int id, EntryRequest entryRequest);

    public Entry DeleteEntryById(int id);
}