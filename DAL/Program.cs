using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ForumDbContext>(options =>
{
    options.UseSqlServer("Data Source=(local);Initial Catalog=OthmenOussema;Trusted_Connection=True; MultipleActiveResultSets=true;Integrated Security=True");
});
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();