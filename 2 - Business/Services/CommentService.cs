using Forum.Bll.Interfaces;
using Forum.Dal.Data;
using Forum.Dal.Repositories;

namespace Forum.Bll.Services
{
    public class CommentService : CommentRepository, ICommentService
    {
        public CommentService(ForumContext context) : base(context)
        {

        }


    }
}
