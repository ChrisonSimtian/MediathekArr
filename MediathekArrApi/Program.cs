var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddMediathekArrApi();

var app = builder.Build();

app.UseMediathekArrApi();

app.Run();
