using Application.Data;
using Application.Interfaces;
using Application.Models.Response;
using Mapster;
using MapsterMapper;

namespace Infrastructure.Services;

public class TodoItemV2Service : ITodoItemsService
{
    private readonly ITimer _timer;
    private readonly IMapper _mapper;
    private readonly IServiceProvider _provider;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationDbContext _context;

    public TodoItemV2Service(ITimer timer, IMapper mapper, IServiceProvider provider, IUserRepository userRepository, IApplicationDbContext context)
    {
        _timer = timer;
        _mapper = mapper;
        _provider = provider;
        _userRepository = userRepository;
        _context = context;
    }
    
    public async Task<IEnumerable<TodoItemResponse>> GetUserItems(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.TodoItems.Adapt<IEnumerable<TodoItemResponse>>();
    }

    public Task<IEnumerable<TodoItemResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItemResponse>> GetOnlyCompleted(string username)
    {
        throw new NotImplementedException();
    }
}