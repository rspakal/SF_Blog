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
    public class TagController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository, ILogger<HomeController> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Tag tag)
        {
            _tagRepository.Create(tag);
            return View();
        }
        public IActionResult Get(int id)
        {
            var tag = _tagRepository.Get(id);
            return View(tag);
        }
        public IActionResult GetAll(int id)
        {
            var tags = _tagRepository.GetAll();
            return View(tags);
        }

        public IActionResult Update(Tag tag)
        {
            _tagRepository.Update(tag);
            return View();
        }

        public IActionResult Delete(int id)
        {
            _tagRepository.Delete(id);
            return View();
        }

    }
}
