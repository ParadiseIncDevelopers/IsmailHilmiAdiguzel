using IsmailHilmiAdiguzelProje;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using IsmailHilmiAdiguzelProje.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Pomelo.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContextPool<MySQLDataContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("DbConnectionString");
    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
