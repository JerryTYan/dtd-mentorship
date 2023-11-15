using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using DTD_Mentorship_Project.Validators;
using DTD_Mentorship_Project.Pages;
using DTD_Mentorship_Project.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add the PersonModel as a scoped service
builder.Services.AddScoped<personModel>();

// Configure HttpClient with required headers
builder.Services.AddHttpClient<locationController>(client =>
{
    client.BaseAddress = new Uri("https://api.zippopotam.us/");
    client.DefaultRequestHeaders.Add("HeaderName", "HeaderValue"); // Add your headers here
});

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
