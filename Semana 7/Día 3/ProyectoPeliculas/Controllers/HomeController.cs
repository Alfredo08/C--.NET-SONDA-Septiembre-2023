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
        Director NuevoDirector = new Director(){
            Id = 123,
            Nombre = "Alex",
            Apellido = "Miller"
        };
        return View("Index", NuevoDirector);
    }

    [HttpGet]
    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }

    [HttpGet]
    [Route("directores")]
    public IActionResult Directores(){
        return View("Directores", ListaDirectores);
    }

    [HttpGet]
    [Route("formulario/director")]
    public IActionResult FormularioDirector(){
        return View("FormularioDirector");
    }

    [HttpPost]
    [Route("nuevo/director")]
    public RedirectToActionResult AgregarDirector(Director NuevoDirector){
        ListaDirectores.Add(NuevoDirector);
        return RedirectToAction("Directores");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
