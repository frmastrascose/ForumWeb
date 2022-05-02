using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ForumProject.Models;
using ForumProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels.Post;
using Forum.Bll.Interfaces;

namespace ForumProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var posts = _postService.GetAll();
            
            var postViewModels = posts.Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    AuthorId = post.Author.Id,
                    AuthorName = post.Author.DisplayName,
                    Created = post.Created.ToString(),
                    CommentsCount = post.Comments.Count()
                });

            var viewModel = new HomeIndexViewModel
            {
                Posts = postViewModels
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
