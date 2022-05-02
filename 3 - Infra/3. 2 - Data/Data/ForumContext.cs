using Forum.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Data
{
    public class ForumContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Post>(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany<Comment>(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<User>()
                .HasMany<Comment>(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
