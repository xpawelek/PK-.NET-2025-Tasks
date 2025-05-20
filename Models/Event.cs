using System.ComponentModel.DataAnnotations;

namespace EventsRegisterer.Models;

public class Event
{
    public int Id {get; set;}

    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public DateTime Date { get; set; }

    public String? Description {get; set;}
}