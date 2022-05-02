using Forum.Dal.Data;
using Forum.Dal.Interfaces;
using Forum.Model.Models;
using Microsoft.AspNetCore.Identity;

namespace Forum.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(ForumContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
