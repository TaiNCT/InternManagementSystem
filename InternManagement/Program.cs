using IMSBussinessObjects;
using IMSBussinessObjects.Data;
using IMSDaos;
using IMSRepositories;
using IMSServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlDbConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserDAO>(); // Register UserDAO
builder.Services.AddScoped<IInternService, InternService>();
builder.Services.AddScoped<IInternRepository, InternRepository>();
builder.Services.AddSingleton<InternDAO>();

// Register other services
builder.Services.AddScoped<IDataaseInitialiser, DatabaseInitialiser>();

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
builder.Services.AddAuthorization();

// Add Razor Pages services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Resolve database initializer
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<IDataaseInitialiser>();

    // Initialize and seed database
    await initializer.InitialiseAsync();
    await initializer.SeedAsync();
}

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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.Run();
