using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using DTD_Mentorship_Project.Validators;
using DTD_Mentorship_Project.Pages;
using DTD_Mentorship_Project.Controllers;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Services.AddValidatorsFromAssemblyContaining<personModel>();


// Add the PersonModel as a scoped service
builder.Services.AddScoped<personModel>();

//Needed to add IValidator<personModel> as scoped service along with the person validator function
builder.Services.AddScoped<IValidator<personModel>, personValidator>();

// Configure HttpClient with required headers
builder.Services.AddHttpClient<SignupController>(client =>
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
