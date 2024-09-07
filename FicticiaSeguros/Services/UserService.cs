using FicticiaSeguros.Models;
using Microsoft.EntityFrameworkCore;

namespace FicticiaSeguros.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string userMail, string userPass)
        {
            User user = await _context.Users.Where(u => u.UserMail == userMail && u.UserPass == userPass).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> SaveUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
