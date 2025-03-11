//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProblemAnalysis2.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//Configure the cookies in Footer
app.Use(async (context, next) =>
{
    if (!context.Request.Cookies.ContainsKey("FirstVisit"))
    {
        context.Response.Cookies.Append("FirstVisit", DateTime.Now.ToString("yyyy-MM-dd"));
    }
    await next.Invoke();
});


app.Run();
