var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlServer")
    .WithDbGate();

var db = sql.AddDatabase("ScheduleLib");

var ScheduleLibMigrationService = builder.AddProject<Projects.ScheduleLib_MigrationService>("ScheduleLibMigrationService")
.WithReference(db)
.WaitFor(db);

builder.Build().Run();
