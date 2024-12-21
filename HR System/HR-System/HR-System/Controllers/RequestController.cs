using HR_System.Helpers;
using HR_System.Models;
using HR_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly UserManager<AppUser> _userManager;
        public RequestController(IRequestRepository requestRepository , UserManager<AppUser> userManager)
        {

            _requestRepository = requestRepository;
            _userManager = userManager;

    }
        public IActionResult Index()
        {
            if(User.IsInRole("HR"))
            {
                var requests = _requestRepository.GetAll().ToList();
                return View(requests);

            }
            else
            {
                var currentUserId = _userManager.GetUserId(User);
                var requests = _requestRepository.GetAllByUserId(currentUserId!).ToList();
                return View(requests);
            }
            
        }


        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        
        public IActionResult Add(Request request)
        {
            var currentUserId = _userManager.GetUserId(User);
            request.AppUserId = currentUserId!;

            request.Status = Helpers.Status.Pending;
            _requestRepository.Add(request);
            _requestRepository.Savechange();
            return RedirectToAction("Index");
        }
        [HttpPut]
        public IActionResult ChangeStatus(int id, int status)
        {
            var request = _requestRepository.GetById(id);
            request.Status = (Status)status;
            _requestRepository.Update(request);
            _requestRepository.Savechange();
            return RedirectToAction("Index");
        }


    }
}
