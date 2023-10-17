using Microsoft.AspNetCore.Mvc;

namespace ProyectoPeliculas.Controllers;

public class PrincipalController : Controller{

    private static List<string> ListaDirectores = new List<string>(){"Martin Scorsese", "Quentin Tarantino", "Billy Wilder", "James Cameron"};

    [HttpGet]
    [Route("")]
    public IActionResult Index(){
        string titulo = "Hola desde ASP y el servidor!!!";
        string subtitulo = "Bienvenidos a la primera vista!!!";
        ViewBag.Titulo = titulo;
        ViewBag.Subtitulo = subtitulo;
        return View("Index");
    }

    [HttpGet("directores")]
    public IActionResult Directores(){
        ViewBag.ListaDirectores = ListaDirectores;
        return View("Directores");
    }

    [HttpGet("mensaje/{nombre}/{apellido}")]
    public string Mensaje(string nombre, string apellido){
        return $"¡Hola como estás {nombre} {apellido}!";
    }

    [HttpGet]
    [Route("tabla/{num}/{limite}")]
    public string TablaDeMultiplicar(int num, int limite){
        string tablaCompleta = "";
        for(int i = 1; i <= limite; i ++){
            int resultado = i * num;
            tablaCompleta += $"{i} x {num} = {resultado}\n";
        }
        return tablaCompleta;
    }

    [HttpGet]
    [Route("procesa/directores")]
    public RedirectToActionResult ProcesaDirectores(){
        Console.WriteLine("Procesando directores!!!");
        return RedirectToAction("Directores");
        // return RedirectToAction("TablaDeMultiplicar", new {num = 10, limite = 20});
    }

    [HttpGet]
    [Route("formulario/director")]
    public IActionResult FormularioDirector(){
        return View("FormularioDirector");
    }

    [HttpPost]
    [Route("nuevo/director")]
    public RedirectToActionResult AgregaDirector(string NombreCompleto){
        ListaDirectores.Add(NombreCompleto);
        return RedirectToAction("Directores");
    }

    [HttpGet]
    [Route("api/directores")]
    public JsonResult APIDirectores(){
        return Json(ListaDirectores);
    }
}
