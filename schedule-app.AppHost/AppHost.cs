var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlServer")
    .WithDbGate();

var db = sql.AddDatabase("ScheduleLib");

var ScheduleLibMigrationService = builder.AddProject<Projects.ScheduleLib_MigrationService>("ScheduleLibMigrationService")
.WithReference(db)
.WaitFor(db);

var ScheduleLibScheduleRunnerService = builder.AddProject<Projects.ScheduleLib_ScheduleRunnerService>("ScheduleLibScheduleRunnerService")
.WithReference(db)
.WaitFor(db)
.WaitForCompletion(ScheduleLibMigrationService);

builder.Build().Run();
