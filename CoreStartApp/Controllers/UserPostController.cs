using CoreStartApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreStartApp.Controllers
{
    public class UserPostController : Controller
    {
        private IBlogRepository _blogRepository;
        private readonly ILogger<UserPostController> _logger;

        public UserPostController(ILogger<UserPostController> logger, IBlogRepository blogRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
