using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Model.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        public DateTime Created { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
