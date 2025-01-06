using MediathekArrApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Database
/* Add DbContext with specific DB Implementation 
 * Uncomment whatever Database you want to use and comment the other one(s) out :-)
 */

/* Postgres SQL */
//builder.Services.AddDbContext<MediathekArrContext>(options => options.UseNpgsql("Host=localhost;Database=tvdb_cache;Username=yourusername;Password=yourpassword"));

/* SQLite */
builder.Services.AddDbContext<MediathekArrContext>(options => options.UseSqlite("Data Source=tvdb_cache.sqlite"));
#endregion

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
