namespace ConsoleApp3.Service;

public interface ITaskService
{
    void CreateTask(string title, string description, int userId);
    List<Models.Task> GetTasksByUsere(int userId);
    void UpdateTaskStatus(int taskId, string status);
}