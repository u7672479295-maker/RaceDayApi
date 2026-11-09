using Microsoft.AspNetCore.Mvc;
using RaceDayWeb.Models;
using RaceDayWeb.Services;

namespace RaceDayWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly ApiService _apiService;


        public EventController(ApiService apiService)
        {
            _apiService = apiService;
        }
    
    [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await _apiService.GetAsync<List<EventViewModel>>("events");
            return View(events ?? new List<EventViewModel>());

        }
        [HttpGet]
        public async Task<IActionResult>Details(int id) 
        {
            var raceEvent = await _apiService.GetAsync<EventViewModel>($"events/{id}");
            if(raceEvent == null)
            {
                return NotFound();
            }
            return View(raceEvent);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var role = HttpContext.Session.GetString("UserRole"); 
            if(role!= "Organiser")
            {
                TempData["ErrorMessage"] = "Access Denied. Only registered Organisers ca create events.";
                return RedirectToAction("Index");   

            }return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.OrganiserUserId = 1;
            var success = await _apiService.PostAsync("events", model);

            if (success)
            {
                TempData["SuccessMessage"] = "Race Event created successfully!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Failed to create event. Please verify API connection");
            return View(model);
        }
    }
}
