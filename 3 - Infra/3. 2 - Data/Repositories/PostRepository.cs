using System.Collections.Generic;
using System.Linq;
using Forum.Dal.Data;
using Forum.Dal.Interfaces;
using Forum.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumContext _context;

        public PostRepository(ForumContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            var result = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .ToList();

            return result;
        }

        public Post GetById(int id)
        {
            var post = _context.Posts.Where(p => p.Id == id)
                .Include(p => p.Author)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Author)
                .FirstOrDefault();

            return post;
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
