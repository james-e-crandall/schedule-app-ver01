namespace ScheduleLib.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleLib.Models;
public class EventItemMap : IEntityTypeConfiguration<ScheduleEventItem>
{
    public void Configure(EntityTypeBuilder<ScheduleEventItem> builder)
    {
        builder.HasKey(ei => ei.Id);
        builder.HasOne(ei => ei.ScheduleItem)
            .WithMany(si => si.ScheduleEventItems)
            .HasForeignKey(ei => ei.ScheduleItemId);
    }
}