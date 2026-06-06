using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ScheduleLib.Data;

namespace ScheduleLib.ScheduleRunnerService;

public class Worker(ILogger<Worker> logger,IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{

    public const string ActivitySourceName = "ScheduleRunner";
    private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var activity = s_activitySource.StartActivity(
            "Schedule Runner", ActivityKind.Client);
        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ScheduleContext>();
            while (!cancellationToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await RunMigrationAsync(dbContext, cancellationToken);
                await Task.Delay(10000, cancellationToken);
            }
            
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }


    }

    private static async Task RunMigrationAsync(
        ScheduleContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Run migration in a transaction to avoid partial migration if it fails.
            var scheduleItems = dbContext.ScheduleItems.ToList();
            foreach(var scheduleItem in scheduleItems)
            {
                if(scheduleItem.ScheduleEventItems.Count == 0)
                {
                    // Add ScheduleEventItems
                }
            }
            var scheduleEventItems = dbContext.ScheduleEventItems.ToList();
            foreach(var scheduleEventItem in scheduleEventItems)
            {
                // If it's time to run ...
            }
        });
    }

}
