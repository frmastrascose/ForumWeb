using System.ComponentModel.DataAnnotations;

namespace Forum.Model.Models
{
    public class Comment : BaseModel
    {
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
