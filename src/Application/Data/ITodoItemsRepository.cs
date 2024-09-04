using Domain;

namespace Application.Data;

public interface ITodoItemsRepository
{
    public IQueryable<TodoItem> Query { get; }
}
