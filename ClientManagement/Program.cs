using ClientManagement.DAL;
using ClientManagement.BusinessLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <seealso href="https://andrewlock.net/exploring-the-new-project-file-program-and-the-generic-host-in-asp-net-core-3/"/>
/// <seealso href="https://stackoverflow.com/questions/71705215/how-to-declare-global-variable-in-program-cs-and-use-it-in-controllers-in-net-6"/>
/// <seealso href="https://www.tutorialsteacher.com/core/aspnet-core-program"/>
/// <seealso href="https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio"/>
/// <seealso href="https://www.c-sharpcorner.com/article/what-is-startup-class-and-program-cs-in-asp-net-core/"/>
/// <seealso href="https://dotnettutorials.net/lesson/routing-asp-net-core-mvc/"/>
/// <seealso href="https://expertbeacon.com/learn-asp-net-core-mvc-net-5-by-building-an-app-with-crud-operations/"/>
// Configure String Connection.
var connectionString = builder.Configuration.GetConnectionString("Clientmanagement_ConnectionString");

// Configure DbContext.
builder.Services.AddDbContext<ClientManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add DiscountService to the container.
builder.Services.AddTransient<DiscountService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialize the database with the in-code created data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ClientManagementDbContext>();
        DatabaseInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        // Log errors.
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
