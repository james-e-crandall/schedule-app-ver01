namespace ScheduleLib.Models;
public class ScheduleEventItem
{
    public int Id { get; set; }
    public ScheduleItem ScheduleItem { get; set; } = null!;
    public int ScheduleItemId { get; set; }
}