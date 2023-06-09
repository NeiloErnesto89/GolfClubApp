using Microsoft.EntityFrameworkCore;
using GolfClubApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// adding membercontext
var connectionString = builder.Configuration.GetConnectionString("MemberContext");
builder.Services.AddSqlite<MemberContext>(connectionString);

// adding bookingcontext
var connectionString2 = builder.Configuration.GetConnectionString("BookingContext");
builder.Services.AddSqlite<BookingContext>(connectionString2);

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
