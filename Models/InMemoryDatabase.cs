namespace EventsRegisterer.Models;

public static class InMemoryDatabase
{
    public static List<Event> Events {get;} = new();
    public static List<Participant> Participants {get;} = new();
}