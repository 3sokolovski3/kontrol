using ConsoleApp3.Data;
using ConsoleApp3.Service;
using ConsoleApp3.ViewModel;

class Program
{
    static void Main()
    {
        var context = new AppDbContext();
        var userService = new UserService(context);
        var taskService = new TaskService(context);
        var viewModel = new MainViewModel(userService, taskService);

        Console.WriteLine("Добро пожаловать в систему управления задачами!");
        Console.Write("Введите логин: ");
        string username = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        if (viewModel.Authenticate(username, password))
        {
            if (viewModel.CurrentUser.RoleId == 1) // Менеджер
            {
                Console.WriteLine("Вы вошли как менеджер.");
                Console.WriteLine("1. Создать задачу");
                Console.WriteLine("2. Зарегистрировать сотрудника");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Название задачи: ");
                    string title = Console.ReadLine();
                    Console.Write("Описание: ");
                    string desc = Console.ReadLine();
                    Console.Write("ID сотрудника: ");
                    int userId = int.Parse(Console.ReadLine());
                    viewModel.CreateTask(title, desc, userId);
                    Console.WriteLine("Задача создана!");
                }
                else if (choice == "2")
                {
                    Console.Write("Логин нового сотрудника: ");
                    string newUsername = Console.ReadLine();
                    Console.Write("Пароль: ");
                    string newPassword = Console.ReadLine();
                    userService.Register(newUsername, newPassword, 2); // Роль сотрудника
                    Console.WriteLine("Сотрудник зарегистрирован!");
                }
            }
            else if (viewModel.CurrentUser.RoleId == 2) // Сотрудник
            {
                Console.WriteLine("Вы вошли как сотрудник.");
                var tasks = viewModel.GetUserTasks();
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.Id}. {task.Title} - {task.Status}");
                }

                Console.Write("Введите ID задачи для изменения статуса: ");
                int taskId = int.Parse(Console.ReadLine());
                Console.Write("Новый статус (To do/In Progress/Done): ");
                string status = Console.ReadLine();
                viewModel.UpdateTaskStatus(taskId, status);
                Console.WriteLine("Статус обновлён!");
            }
        }
        else
        {
            Console.WriteLine("Ошибка авторизации!");
        }
    }
}
