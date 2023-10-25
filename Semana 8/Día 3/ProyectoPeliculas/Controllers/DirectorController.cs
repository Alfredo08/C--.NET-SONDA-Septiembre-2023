#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoPeliculas.Models;

namespace ProyectoPeliculas.Controllers;

public class DirectorController : Controller{
    public static List<Director> ListaDirectores = new List<Director>();

    private readonly ILogger<DirectorController> _logger;
    private MyContext _context;

    public DirectorController(ILogger<DirectorController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [SessionCheck]
    [Route("privacy")]
    public IActionResult Privacy(){
        return View("Privacy");
    }

    [HttpGet]
    [SessionCheck]
    [Route("directores")]
    public IActionResult Directores(){
                                            /* SELECT *
                                               FROM directores; */
        List<Director> ListaDirectoresLINQ = _context.Directores.ToList();
        return View("Directores", ListaDirectoresLINQ);
    }

    [HttpGet]
    [Route("registro")]
    public IActionResult Registro(){
        return View("Registro");
    }

    [HttpPost]
    [Route("procesa/registro")]
    public IActionResult ProcesaRegistro(Director NuevoDirector){
        if(ModelState.IsValid){
            PasswordHasher<Director> Hasher = new PasswordHasher<Director>();
            NuevoDirector.Password = Hasher.HashPassword(NuevoDirector, NuevoDirector.Password);
            _context.Directores.Add(NuevoDirector);
            _context.SaveChanges();
            return RedirectToAction("Login");      
        }
        return View("Registro");
        
    }

    [HttpGet]
    [Route("procesa/logout")]
    public IActionResult ProcesaLogout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
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
            Director? director = _context.Directores.FirstOrDefault(dir => dir.Email == login.Email);

            if(director != null){
                PasswordHasher<Login> Hasher = new PasswordHasher<Login>();
                var result = Hasher.VerifyHashedPassword(login, director.Password, login.Password);

                if(result != 0){
                    HttpContext.Session.SetString("Nombre", director.Nombre);
                    HttpContext.Session.SetString("Apellido", director.Apellido);
                    HttpContext.Session.SetString("Email", director.Email);
                    HttpContext.Session.SetInt32("Id", director.Id);
                    return RedirectToActionResult("Peliculas", "Pelicula", null);
                }
            }
            ModelState.AddModelError("Password", "Credenciales incorrectas");
            return View("Login");
        }
        return View("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        string? email = context.HttpContext.Session.GetString("Email");
        // Check to see if we got back null
        if(email == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Login", "Home", null);
        }
    }
}