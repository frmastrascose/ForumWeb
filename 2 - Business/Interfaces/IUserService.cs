using System.Threading.Tasks;

namespace Forum.Bll.Interfaces
{
    public interface IUserService
    {
        Task<int> GetPostsCountAsync(int userId);
        Task<int> GetCommentsCountAsync(int userId);
    }
}
