using ConsoleApp3.Models;

namespace ConsoleApp3.Service;

public interface IUserService
{
    User Authenticate(string username, string password);
    void Register(string username, string password, int roleId);
}