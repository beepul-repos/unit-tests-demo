using Application.Data;
using Application.Interfaces;
using Application.Models.Response;
using Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoItemService : ITodoItemsService
{
    private readonly IUserRepository _userRepository;
    private readonly ITodoItemsRepository _todoItemsRepository;

    public TodoItemService(IUserRepository userRepository, ITodoItemsRepository todoItemsRepository)
    {
        _userRepository = userRepository;
        _todoItemsRepository = todoItemsRepository;
    }
    
    public async Task<IEnumerable<TodoItemResponse>> GetUserItems(string username)
    {
        AppUser? user = await _userRepository.GetByUsernameAsync(username);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.TodoItems.Adapt<IEnumerable<TodoItemResponse>>();
    }

    public async Task<IEnumerable<TodoItemResponse>> GetAll()
    {
        // FOR TEST
        TodoItem? todo = await _todoItemsRepository.Query.FirstOrDefaultAsync();
        if (todo is null)
        {
            throw new Exception("Not found any todo");
        }
        
        var items = await _todoItemsRepository.Query
            .AsNoTracking()
            .ProjectToType<TodoItemResponse>()
            .ToListAsync();

        return items;
    }

    public async Task<IEnumerable<TodoItemResponse>> GetOnlyCompleted(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        var todo = await _todoItemsRepository.Query.FirstOrDefaultAsync();
        if (todo is null)
        {
            throw new Exception("Not found any todo");
        }

        var list = await _todoItemsRepository.Query
            .Where(x => x.UserId == user.Id && x.CompletedDate != null)
            .ProjectToType<TodoItemResponse>()
            .ToListAsync();

        return list;
    }
}