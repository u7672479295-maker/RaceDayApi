using Microsoft.AspNetCore.Mvc;
using RaceDayWeb.Models;
using RaceDayWeb.Services;

namespace RaceDayWeb.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly ApiService _apiService;

        public EnrolmentsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int eventId)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Participant")
            {
                TempData["ErrorMessage"] = "Only Participants can enrol in race events.";
                return RedirectToAction("Index", "Events");
            }

            var raceEvent = await _apiService.GetAsync<EventViewModel>($"events/{eventId}");
            if (raceEvent == null) return NotFound();

            var viewModel = new CreateEnrolmentViewModel
            {
                EventId = eventId,
                EventName = raceEvent.Name,
                AvailableCategories = raceEvent.Categories ?? new List<CategoryViewModel>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEnrolmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var postData = new
            {
                ParticipantUserId = 3,
                EventId = model.EventId,
                CategoryId = model.CategoryId
            };

            var success = await _apiService.PostAsync("enrolments", postData);

            if (success)
            {
                TempData["SuccessMessage"] = "Successfully enrolled in race event!";
                return RedirectToAction("MyEnrolments");
            }

            ModelState.AddModelError(string.Empty, "Unable to process enrolment.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyEnrolments()
        {
            int participantUserId = 3;
            var enrolments = await _apiService.GetAsync<List<ParticipantEnrolmentViewModel>>($"enrolments/participant/{participantUserId}");

            return View(enrolments ?? new List<ParticipantEnrolmentViewModel>());
        }
    }
}