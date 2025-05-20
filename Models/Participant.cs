using System.ComponentModel.DataAnnotations;

namespace EventsRegisterer.Models;

public class Participant
{
    public int Id {get; set;}
    [Required]
    public String Name {get; set;}
    [Required]
    [EmailAddress]
    public String Email {get; set;}

    public int EventId {get; set;}
}