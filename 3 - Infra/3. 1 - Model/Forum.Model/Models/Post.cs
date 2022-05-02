using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Model.Models
{
    public class Post : BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public bool IsEdited { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
