using System.Linq;
using System.Threading.Tasks;
using Forum.Bll.Interfaces;
using Forum.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> GetCommentsCountAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Comments)
                .SingleAsync(u => u.Id == userId);

            return user.Comments.Count();
        }

        public async Task<int> GetPostsCountAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Posts)
                .SingleAsync(u => u.Id == userId);

            return user.Posts.Count();
        }
    }
}
