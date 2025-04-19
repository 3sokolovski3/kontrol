using ConsoleApp3.Data;

namespace ConsoleApp3.Service
{
    public class TaskService: ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTask(string title, string description, int userId)
        {
            var task = new Models.Task
            {
                Title = title,
                Description = description,
                IdUser = userId,
                Status = "To do"
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<Models.Task> GetTasksByUsere(int userId)
        {
            return _context.Tasks.Where(t => t.IdUser == userId).ToList();
        }

        public void UpdateTaskStatus(int taskId, string status)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new Exception("Задача не найдена.");
            task.Status = status;
            _context.SaveChanges();
        }
    }
}
