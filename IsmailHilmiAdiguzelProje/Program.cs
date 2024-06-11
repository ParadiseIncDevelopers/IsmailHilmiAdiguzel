using IsmailHilmiAdiguzelProje;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using IsmailHilmiAdiguzelProje.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrganisationUserService, OrganisationUserService>();
builder.Services.AddScoped<IUserClickCounterService, UserClickCounterService>();

builder.Services.AddDbContextPool<MySQLDataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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