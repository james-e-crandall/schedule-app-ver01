using ScheduleLib.Data;
using ScheduleLib.ScheduleRunnerService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerDbContext<ScheduleContext>(connectionName: "ScheduleLib");

builder.EnrichSqlServerDbContext<ScheduleContext>();


builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
