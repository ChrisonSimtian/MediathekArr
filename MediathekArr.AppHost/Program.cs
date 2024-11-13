var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MediathekArr_Api>("mediathekarr-api");

builder.AddProject<Projects.MediathekArr>("mediathekarr");

builder.Build().Run();
