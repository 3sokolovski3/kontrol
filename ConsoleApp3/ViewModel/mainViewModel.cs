using ConsoleApp3.Models;
using ConsoleApp3.Service;

namespace ConsoleApp3.ViewModel;

public class MainViewModel
{
    private readonly IUserService _userService;
    private readonly ITaskService _taskService;
    public User? CurrentUser { get; private set; }

    public MainViewModel(IUserService userService, ITaskService taskService)
    {
        _userService = userService;
        _taskService = taskService;
    }

    public bool Authenticate(string username, string password)
    {
        try
        {
            CurrentUser = _userService.Authenticate(username, password);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void CreateTask(string title, string description, int userId)
    {
        _taskService.CreateTask(title, description, userId);
    }

    public List<Models.Task> GetUserTasks()
    {
        return _taskService.GetTasksByUsere(CurrentUser!.Id);
    }

    public void UpdateTaskStatus(int taskId, string status)
    {
        _taskService.UpdateTaskStatus(taskId, status);
    }
}
