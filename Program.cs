using Microsoft.EntityFrameworkCore;
using tourismApp.Data;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var username = Environment.GetEnvironmentVariable("DB_USER");
var password= Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Host={host};Database={database};Port={port};Username={username};Password={password}";
// Add services to the container.
builder.Services.AddControllersWithViews();


// Configura PostgreSQL como proveedor de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

DotNetEnv.Env.Load();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicializa la base de datos (opcional para desarrollo)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();  // Creará la base de datos si no existe
}

app.Run();
