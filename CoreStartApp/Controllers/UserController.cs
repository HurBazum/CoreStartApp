using CoreStartApp.DAL;
using CoreStartApp.Models.Entities;
using CoreStartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CoreStartApp.Controllers
{
    public class UserController : Controller
    {
        private IBlogRepository _blogRepository;
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger, IBlogRepository blogRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            User[] users = await _blogRepository.GetUsers();

            return View(users);
        }
        [HttpGet]
        public IActionResult Registrate()
        {
            return View();
        }

        // добавление юзера 
        [HttpPost]
        public async Task<IActionResult> Registrate(User user)
        {
            if (_blogRepository.GetUsers().Result.ToList().Find(u => u.FirstName == user.FirstName && u.LastName == user.LastName) != null)
            {
                return View("UserAlreadyExists");
            }
            else
            {
                await _blogRepository.AddUser(user);
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult SearchUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchUser(int? index)
        {

            return View(await _blogRepository.GetUser(index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}