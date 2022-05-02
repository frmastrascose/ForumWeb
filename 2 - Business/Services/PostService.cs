using Forum.Dal.Repositories;
using Forum.Bll.Interfaces;
using Forum.Dal.Data;

namespace Forum.Bll.Services
{
    public class PostService : PostRepository, IPostService
    {
        public PostService(ForumContext context) : base(context)
        {

        }


    }
}
