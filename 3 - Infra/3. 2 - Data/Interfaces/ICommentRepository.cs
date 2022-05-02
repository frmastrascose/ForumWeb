
using Forum.Model.Models;

namespace Forum.Dal.Interfaces
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
    }
}
