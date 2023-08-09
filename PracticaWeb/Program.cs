using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaWeb.Data;
using PracticaWeb.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(new SqlDataAccess(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/Access/Login"; 
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options => {
	options.Filters.Add(new ResponseCacheAttribute
	{
		NoStore = true,
		Location = ResponseCacheLocation.None,
	});
});
builder.Services.AddScoped<IUsuario, Usuario>();
builder.Services.AddScoped<IAutos, Autos>();
builder.Services.AddScoped<ISalidas, Salidas>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}"); 

app.Run();
