using Microsoft.EntityFrameworkCore;
using ScheduleLib.Models;

namespace ScheduleLib.Data
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }
        public DbSet<ScheduleItem> ScheduleItems => Set<ScheduleItem>();
        public DbSet<EventItem> EventItems => Set<EventItem>();
        public DbSet<ScheduleEventItem> ScheduleEventItems => Set<ScheduleEventItem>();

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleContext).Assembly);
        }
    }
}