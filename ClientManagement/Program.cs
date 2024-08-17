using ClientManagement.DAL;
using ClientManagement.BusinessLogic; // Importar o namespace para DiscountService
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conex�o
var connectionString = builder.Configuration.GetConnectionString("Clientmanagement_ConnectionString");

// Configurar o DbContext
builder.Services.AddDbContext<ClientManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar o DiscountService
builder.Services.AddTransient<DiscountService>();

// Adicionar servi�os ao cont�iner
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Inicializar o banco de dados com dados fict�cios
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
        // Logar erros
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configurar o pipeline de solicita��o HTTP
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
