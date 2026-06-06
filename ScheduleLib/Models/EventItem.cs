namespace ScheduleLib.Models;
public class EventItem
{
    public int Id { get; set; }
    public ScheduleItem ScheduleItem { get; set; } = null!;
    public int ScheduleItemId { get; set; }
}