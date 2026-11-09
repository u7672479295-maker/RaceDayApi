using Microsoft.AspNetCore.Mvc;
using RaceDayWeb.Models;
using RaceDayWeb.Services;

namespace RaceDayWeb.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ApiService _apiService;

        public ResultsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> EventResults(int eventId)
        {
            var raceEvent = await _apiService.GetAsync<EventViewModel>($"events/{eventId}");
            ViewBag.EventName = raceEvent != null ? raceEvent.Name : "Race Results";
            ViewBag.EventId = eventId;

            var results = await _apiService.GetAsync<List<LeaderboardResultViewModel>>($"results/event/{eventId}");
            return View(results ?? new List<LeaderboardResultViewModel>());
        }

        [HttpGet]
        public IActionResult Create(int enrolmentId, int eventId)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Organiser")
            {
                TempData["ErrorMessage"] = "Access denied. Only Organisers can capture race results.";
                return RedirectToAction("Index", "Events");
            }

            var model = new CreateResultViewModel
            {
                EnrolmentId = enrolmentId,
                EventId = eventId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateResultViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _apiService.PostAsync("results", model);

            if (success)
            {
                TempData["SuccessMessage"] = "Race result recorded successfully!";
                return RedirectToAction("EventResults", new { eventId = model.EventId });
            }

            ModelState.AddModelError(string.Empty, "Failed to record result.");
            return View(model);
        }
    }
}

