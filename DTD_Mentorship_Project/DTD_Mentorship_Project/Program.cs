using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(540);
});
// builder.Services.AddMediatR();
//builder.Services.AddDbContext<DTD_Mentorship_Project.Models.DBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAZURECONNSTR_DTDDB"));
//});

// Add services to the container.
builder.Services.AddRazorPages();



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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
