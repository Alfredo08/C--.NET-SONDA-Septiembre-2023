using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoPeliculas.Models;

namespace ProyectoPeliculas.Controllers;

public class HomeController : Controller
{
    public static List<Director> ListaDirectores = new List<Director>();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        return View("Index");
    }

    [HttpGet]
    [Route("privacy")]
    public IActionResult Privacy(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        return View("Privacy");
    }

    [HttpGet]
    [Route("directores")]
    public IActionResult Directores(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        return View("Directores", ListaDirectores);
    }

    [HttpGet]
    [Route("formulario/director")]
    public IActionResult FormularioDirector(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        return View("FormularioDirector");
    }

    [HttpPost]
    [Route("nuevo/director")]
    public IActionResult AgregarDirector(Director NuevoDirector){
        if(ModelState.IsValid){
            ListaDirectores.Add(NuevoDirector);
            return RedirectToAction("Directores");      
        }
        return View("FormularioDirector");
        
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login(){
        return View("Login");
    }

    [HttpPost]
    [Route("procesa/login")]
    public IActionResult ProcesaLogin(Login login){
        if(ModelState.IsValid){
            foreach(Director director in ListaDirectores){
                if(director.Email == login.Email && director.Password == login.Password){
                    HttpContext.Session.SetString("Nombre", director.Nombre);
                    HttpContext.Session.SetString("Apellido", director.Apellido);
                    HttpContext.Session.SetString("Email", director.Email);
                    return RedirectToAction("Index");
                }
            }
            // Falta enviar mensaje de error "Credenciales incorrectas"
            ModelState.AddModelError("Password", "The username or password is incorrect");
            return View("Login");
        }
        return View("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
