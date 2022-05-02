using Forum.Dal.Data;
using Forum.Dal.Interfaces;
using Forum.Model.Models;

namespace Forum.Dal.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumContext _context;
        public CommentRepository(ForumContext context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
