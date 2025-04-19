using ConsoleApp3.Data;
using ConsoleApp3.Models;

namespace ConsoleApp3.Service
{
    
    public class UserService : IUserService
    {
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public User Authenticate(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
            throw new Exception("Неверный логин или пароль.");
        return user;
    }

    public void Register(string username, string password, int roleId)
    {
        var user = new User { Username = username, Password = password, RoleId = roleId };
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    }

}
