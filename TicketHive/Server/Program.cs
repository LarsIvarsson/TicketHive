using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Server.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityDbString = builder.Configuration.GetConnectionString("IdentityDbConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(identityDbString));

var eventsDbString = builder.Configuration.GetConnectionString("EventsDbConnection") ?? throw new InvalidOperationException("Connection string 'EventsDbConnection' not found.");
builder.Services.AddDbContext<EventsDbContext>(options =>
	options.UseSqlServer(eventsDbString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
	var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
	var signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

	context.Database.Migrate();

	// creates admin user 
	ApplicationUser? adminUser = signInManager.UserManager.FindByNameAsync("admin").GetAwaiter().GetResult();
	if (adminUser == null)
	{
		adminUser = new() { UserName = "admin", Country = "Sweden" };
		signInManager.UserManager.CreateAsync(adminUser, "Password1234!").GetAwaiter().GetResult();
	}

	// creates admin role
	IdentityRole? adminRole = roleManager.FindByNameAsync("Admin").GetAwaiter().GetResult();
	if (adminRole == null)
	{
		adminRole = new() { Name = "Admin" };
		roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
	}
	signInManager.UserManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();

	// creates normal user
	ApplicationUser? appUser = signInManager.UserManager.FindByNameAsync("user").GetAwaiter().GetResult();
	if (appUser == null)
	{
		appUser = new() { UserName = "user", Country = "Sweden" };
		signInManager.UserManager.CreateAsync(appUser, "Password1234!").GetAwaiter().GetResult();
	}
}

builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
	{
		options.IdentityResources["openid"].UserClaims.Add("role");
		options.ApiResources.Single().UserClaims.Add("role");
	});

builder.Services.AddAuthentication()
	.AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IEventsRepo, EventsRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
