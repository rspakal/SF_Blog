using AutoMapper;
using HedonismBlog.DAL.Repositories;
using HedonismBlog.DataAccess.Repositories;
using HedonismBlog.Models;
using HedonismBlog.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using static HedonismBlog.DAL.Repositories.RoleRepository;
using static HedonismBlog.Models.Role;

namespace HedonismBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository; 
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository, ILogger<HomeController> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository =  roleRepository;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Get(id);
            return View(user);
        }
        public IActionResult GetAll(int id)
        {
            var users = _userRepository.GetAll();
            return View(users);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(User user) 
        {
            _userRepository.Update(user);
            return View();
        }


        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return View();
        }

    }
}
