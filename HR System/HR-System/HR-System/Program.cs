using HR_System.Models;
using HR_System.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(
	option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
	);

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddRazorPages().;

//builder.Services.AddRazorPages();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// In Startup.cs (for .NET Core 3.1 or earlier)


app.UseEndpoints(endpoints =>
{
	endpoints.MapRazorPages();
});

app.Run();
