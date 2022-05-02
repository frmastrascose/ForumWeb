using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels.Post;
using ForumProject.ViewModels.Comment;
using Microsoft.AspNetCore.Identity;
using Forum.Bll.Interfaces;
using Forum.Model.Models;

namespace ForumProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        [Route("/post/create")]
        public IActionResult Create()
        {

            var viewModel = new CreatePostViewModel
            {
                AuthorName = User.Identity.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [Route("post/create")]
        public async Task<IActionResult> Create(CreatePostViewModel viewModel)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);


            var post = new Post
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                Created = DateTime.Now,
                Author = user
            };

            _postService.Add(post);
            return RedirectToAction("Details", "Post", new { id = post.Id});
        }

        [HttpGet]
        [Route("post/details/{id}")]
        public IActionResult Details(int id)
        {
            var userId = 0;
            var post = _postService.GetById(id);
            if (User.Identity.IsAuthenticated)
                userId = int.Parse(_userManager.GetUserId(User));

            var comments = post.Comments.Select(c => new CommentViewModel
            {
               Id = c.Id,
               AuthorId = c.Id,
               AuthorName = c.Author.DisplayName,
               Content = c.Content,
               Created = c.Created,
               PostId = c.Post.Id
            });
            var viewModel = new PostDetailsViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.AuthorId,
                AuthorName = post.Author.DisplayName,
                Created = post.Created,
                Content = post.Content,
                IsEdited = post.IsEdited,
                Comments = comments,
                CanModify = userId == post.AuthorId
            };

            return View(viewModel);
        }


        [HttpGet]
        [Route("post/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                ViewBag.ErrorMessage = "Post is not found!";
                return View("NotFound");
            }

            _postService.Delete(post);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("post/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                ViewBag.Message = "Post is not found";
                return View("NotFound");
            }

            var viewModel = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.Author.DisplayName,
                Created = post.Created,
                Content = post.Content
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("post/edit/{id}")]
        public IActionResult Edit(PostEditViewModel viewModel, int id)
        {
            var post = _postService.GetById(id);

            post.Title = viewModel.Title;
            post.Content = viewModel.Content;
            post.IsEdited = true;

            _postService.Update(post);

            return RedirectToAction("Details", "Post", new { id = id });
        }
    }
}