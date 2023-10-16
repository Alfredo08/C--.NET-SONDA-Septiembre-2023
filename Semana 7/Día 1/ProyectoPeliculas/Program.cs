var builder = WebApplication.CreateBuilder(args);
// Indicarle al servidor que utilizaremos la arquitectura de MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configuración para utilizar rutas, archivos estáticos y autentificación
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",    
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
