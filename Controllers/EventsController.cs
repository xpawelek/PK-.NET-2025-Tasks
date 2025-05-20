using EventsRegisterer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsRegisterer.Controllers;

public class EventsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Events = InMemoryDatabase.Events;
        return View();
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        ViewBag.Events = InMemoryDatabase.Events;
        ViewBag.SelectedId = id;
        return View("~/Views/Home/Events.cshtml");
    }
    
    [HttpPost]
    public IActionResult Create(Event model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Events = InMemoryDatabase.Events;
            return View("Index", model);
        }
        model.Id = InMemoryDatabase.Events.Count + 1;
        InMemoryDatabase.Events.Add(model);
        ViewBag.Events = InMemoryDatabase.Events;

        return View("~/Views/Home/Events.cshtml", model);
    }
}