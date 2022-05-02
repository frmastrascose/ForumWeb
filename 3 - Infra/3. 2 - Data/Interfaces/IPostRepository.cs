using Forum.Model.Models;
using System.Collections.Generic;

namespace Forum.Dal.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void Add(Post post);
        void Delete(Post post);
        void Update(Post post);
    }
}
