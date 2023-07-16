using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreStartApp.Models.Entities;
using CoreStartApp.DAL;

namespace CoreStartApp.Controllers
{
    public class RequestController : Controller
    {
        IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }


        public async Task<IActionResult> Index()
        {
            Request[] requestsToUs = await _requestRepository.GetRequests();
            return View(requestsToUs);
        }
    }
}
