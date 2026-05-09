using Microsoft.EntityFrameworkCore;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//SQLite baglantisi
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=trackadvisor.db"));

// AuthService dependency injection ile eklendi
builder.Services.AddScoped<AuthService>();

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

    if (!db.Topics.Any())
    {
        db.Topics.Add(new Topic { Name = "Software Development", Description = "Software development track" });
        db.Topics.Add(new Topic { Name = "Cyber Security", Description = "Cyber security track" });
        db.Topics.Add(new Topic { Name = "Business IT", Description = "Business IT track" });
        db.SaveChanges();
    }
}

app.Run();
