using CoreStartApp.Models;
using CoreStartApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreStartApp.Controllers
{
    public class FeedbackController : Controller
    {
        /// <summary>
        /// Метод, возвращающий страницу с отзывами
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FeedBack feedBack)
        {
            return StatusCode(200, $"{feedBack.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
