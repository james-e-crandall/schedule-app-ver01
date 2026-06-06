namespace ScheduleLib.Models;
public class ScheduleItem
{
    public int Id { get; set; }

    public List<ScheduleEventItem> ScheduleEventItems { get; set; } = new();
    public List<EventItem> EventItems { get; set; } = new();
}