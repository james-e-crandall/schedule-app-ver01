using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleLib.Models;

namespace ScheduleLib.Maps;
public class ScheduleEventItemMap : IEntityTypeConfiguration<ScheduleEventItem>
{
    public void Configure(EntityTypeBuilder<ScheduleEventItem> builder)
    {
        builder.HasKey(sei => sei.Id);
        builder.HasOne(sei => sei.ScheduleItem)
            .WithMany(si => si.ScheduleEventItems)
            .HasForeignKey(sei => sei.ScheduleItemId);
    }
}