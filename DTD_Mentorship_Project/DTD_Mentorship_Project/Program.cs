using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using DTD_Mentorship_Project.Pages;
using DTD_Mentorship_Project.Models;
using DTD_Mentorship_Project;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(540);
});
// builder.Services.AddMediatR();
builder.Services.AddDbContext<DTD_Mentorship_Project.Models.DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAZURECONNSTR_DTDDB"));
});



//configure kestrel for HTTPS
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5101);  // HTTP port
    options.ListenAnyIP(7277, listenOptions => listenOptions.UseHttps());  // HTTPS port
});

// Add services to the container.
builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

// Redirect the root URL to /Profile/Dashboard
app.MapGet("/", context =>
{
    context.Response.Redirect("/Profile/Dashboard");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
