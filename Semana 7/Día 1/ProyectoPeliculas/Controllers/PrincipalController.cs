using Microsoft.AspNetCore.Mvc;

namespace ProyectoPeliculas.Controllers;

public class PrincipalController : Controller{

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
        string[] listaDirectores = {"Martin Scorsese", "Quentin Tarantino", "Billy Wilder", "James Cameron"};
        ViewBag.ListaDirectores = listaDirectores;
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
}
