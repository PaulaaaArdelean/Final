using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Final.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});



// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Rochii");
    options.Conventions.AllowAnonymousToPage("/Rochii/Index");
    options.Conventions.AllowAnonymousToPage("/Rochii/Details");
    options.Conventions.AuthorizeFolder("/Cliente", "AdminPolicy");



});
builder.Services.AddDbContext<FinalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinalContext") ?? throw new InvalidOperationException("Connection string 'FinalContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("FinalContext") ?? throw new InvalidOperationException("Connection string 'FinalContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
