using Note.Api.Models;
using Note.Api.Exceptions;
using Note.Api.Models.Interface;

namespace Note.Api.Data;

public class Database
{
    public List<Entry> entries = [];

    public T FindItemById<T>(List<T> list, int id) where T : IIdentifiable
    {
        var item = list.Find(item => item.Id == id);

        if (item == null && typeof(T) == typeof(Entry))
        {
            throw new NoEntryFoundException();
        }

        return item!;
    }
}