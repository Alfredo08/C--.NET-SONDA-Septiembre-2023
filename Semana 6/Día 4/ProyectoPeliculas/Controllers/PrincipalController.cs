using Microsoft.AspNetCore.Mvc;

namespace ProyectoPeliculas.Controllers;

public class PrincipalController : Controller{

    [HttpGet]
    [Route("")]
    public string Index(){
        return "Hola desde el controlador principal en la rute '/'";
    }

    [HttpGet("directores")]
    public string Directores(){
        return "Martin Scorsese\nQuentin Tarantino\nBilly Wilder";
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
