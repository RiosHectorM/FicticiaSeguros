using FicticiaSeguros.Models;

namespace FicticiaSeguros.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string userMail, string userPass);
        Task<User> SaveUser(User user);
    }
}
