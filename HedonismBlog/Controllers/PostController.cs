using HedonismBlog.DataAccess.Repositories;
using HedonismBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HedonismBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository, ILogger<HomeController> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Post post)
        {
            _postRepository.Create(post);
            return View();
        }
        public IActionResult Get(int id)
        {
            var post = _postRepository.Get(id);
            return View(post);
        }
        public IActionResult GetAll(int id)
        {
            var allPosts = _postRepository.GetAll();
            return View(allPosts);
        }

        public IActionResult GetByUserId(int userId) 
        {
            var userPosts = _postRepository.GetByUserId(userId);
            return View(userPosts);
        }
        public IActionResult Update(Post post)
        {
            _postRepository.Update(post);
            return View();
        }

        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return View();
        }

    }
}
