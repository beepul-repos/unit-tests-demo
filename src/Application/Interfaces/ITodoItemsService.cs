using Application.Models.Response;

namespace Application.Interfaces;

public interface ITodoItemsService
{
    Task<IEnumerable<TodoItemResponse>> GetAll();
    Task<IEnumerable<TodoItemResponse>> GetOnlyCompleted(string username);
    Task<IEnumerable<TodoItemResponse>> GetUserItems(string username);
}
