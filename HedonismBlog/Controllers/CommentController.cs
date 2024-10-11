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

    public class CommentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository, ILogger<HomeController> logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Comment comment)
        {
            _commentRepository.Create(comment);
            return View();
        }

        public IActionResult Get(int id)
        {
            var comment = _commentRepository.Get(id);
            return View(comment);
        }

        public IActionResult GetAll(int id)
        {
            var comments = _commentRepository.GetAll();
            return View(comments);
        }

        public IActionResult Update(Comment comment)
        {
            _commentRepository.Update(comment);
            return View();
        }

        public IActionResult Delete(int id)
        {
            _commentRepository.Delete(id);
            return View();
        }

    }
}
