using Microsoft.EntityFrameworkCore;
using ScheduleLib.Data;
using ScheduleLib.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContextPool<ScheduleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScheduleLib"), sqlOptions =>
        sqlOptions.MigrationsAssembly("ScheduleLib.MigrationService")
    ));
builder.EnrichSqlServerDbContext<ScheduleContext>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
