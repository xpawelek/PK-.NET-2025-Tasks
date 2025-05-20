using EventsRegisterer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsRegisterer.Controllers;

public class ParticipantController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Participants = InMemoryDatabase.Participants;
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Participant model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Participants = InMemoryDatabase.Participants;
            return View("Index", model);
        }
        model.Id = InMemoryDatabase.Participants.Count + 1;
        InMemoryDatabase.Participants.Add(model);
        ViewBag.Participants = InMemoryDatabase.Participants;

        return View("~/Views/Home/Participants.cshtml", model);
    }
    
    [HttpGet]
    public IActionResult EventParticipants(int? id)
    {
        if (id == null)
        {
            return BadRequest("Event ID is required.");
        }

        var matchingParticipants = InMemoryDatabase.Participants
            .Where(p => p.EventId == id)
            .ToList();

        ViewBag.Participants = matchingParticipants;
        ViewBag.SelectedEventId = id;

        return View("~/Views/Home/Participants.cshtml");
    }
}