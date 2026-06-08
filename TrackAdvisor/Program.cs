using Microsoft.EntityFrameworkCore;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.DAL.Repositories;
using TrackAdvisor.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//SQLite connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=trackadvisor.db"));

// AuthService is added with dependency injection 
builder.Services.AddScoped<IUserRepository, TrackAdvisor.DAL.Repositories.UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    var topicRepo = new TopicRepository(db);
    topicRepo.InitializeTopics();
}
app.Run();
