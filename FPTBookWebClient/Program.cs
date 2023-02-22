using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using FPTBookWebClient.Data;
using FPTBookWebClient.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultUI()
	.AddDefaultTokenProviders();

builder.Services.AddScoped<IFileService, FileService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapAreaControllerRoute(
	name: "areas",
	areaName: "Owners",
	pattern: "Owners/{controller=Order}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
	name: "areas",
	areaName: "Admins",
	pattern: "Admins/{controller=Owner}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
	await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.Run();
