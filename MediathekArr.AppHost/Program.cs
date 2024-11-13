var builder = DistributedApplication.CreateBuilder(args);

var dbServer = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithLifetime(ContainerLifetime.Persistent)
    ;
var database = dbServer.AddDatabase("MediathekArr");

builder
    .AddProject<Projects.MediathekArr_Api>("mediathekarr-api")
    .WithReference(database)
    .WaitFor(database)
    ;

builder
    .AddProject<Projects.MediathekArr>("mediathekarr")
    .WithReference(database)
    .WaitFor(database)
    ;

builder.Build().Run();
