var builder = DistributedApplication.CreateBuilder(args);

var dbServer = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    ;
var database = dbServer.AddDatabase("MediathekArr");

builder
    .AddProject<Projects.MediathekArr_Api>("mediathekarr-api")
    .WithReference(database);

builder
    .AddProject<Projects.MediathekArr>("mediathekarr")
    .WithReference(database);

builder.Build().Run();
