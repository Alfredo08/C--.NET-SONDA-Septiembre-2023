#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoPeliculas.Models;

namespace ProyectoPeliculas.Controllers;

public class PeliculaController : Controller{
    public static List<Director> ListaDirectores = new List<Director>();

    private readonly ILogger<PeliculaController> _logger;
    private MyContext _context;

    public PeliculaController(ILogger<PeliculaController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }
    /* RUTAS GET */
    [HttpGet]
    [SessionCheck]
    [Route("peliculas")]
    public IActionResult Peliculas(){
        List<Pelicula> ListaPeliculas = _context.Peliculas.Include(peli => peli.Creador).ToList();
        foreach(Pelicula peli in ListaPeliculas){
            Console.WriteLine(peli.Titulo);
            Console.WriteLine(peli.Creador);
        }
        return View("Peliculas", ListaPeliculas);
    }

    [HttpGet]
    [SessionCheck]
    [Route("formulario/pelicula")]
    public IActionResult FormularioPelicula(){
        return View("FormularioPelicula");
    }

    [HttpGet]
    [SessionCheck]
    [Route("formulario/editar/pelicula/{id_pelicula}")]
    public IActionResult FormularioEditarPelicula(int id_pelicula){
        Pelicula? pelicula = _context.Peliculas.FirstOrDefault(peli => peli.PeliculaId == id_pelicula);
        return View("FormularioEditarPelicula", pelicula);
    }

    /* RUTAS POST */
    [HttpPost]
    [Route("nueva/pelicula")]
    public IActionResult AgregarPelicula(Pelicula pelicula){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        if(ModelState.IsValid){
            /* INSERT INTO pelicula(titulo, genero, anio, descripcion, director_id)
               VALUES(titulo, genero, anio, descripcion, director_id); */
            pelicula.DirectorId = (int)HttpContext.Session.GetInt32("Id");
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
            return RedirectToAction("Peliculas");
        }
        return View("FormularioPelicula");
    }

    [HttpPost]
    [Route("elimina/pelicula/{id_pelicula}")]
    public IActionResult EliminaPelicula(int id_pelicula){
        Pelicula? pelicula = _context.Peliculas.FirstOrDefault(peli => peli.PeliculaId == id_pelicula);
        _context.Peliculas.Remove(pelicula);
        _context.SaveChanges();
        return RedirectToAction("Peliculas");
    }

    [HttpPost]
    [Route("actualiza/pelicula/{id_pelicula}")]
    public IActionResult ActualizaPelicula(Pelicula pelicula, int id_pelicula){
        Pelicula? peliculaPrevia = _context.Peliculas.FirstOrDefault(peli => peli.PeliculaId == id_pelicula);

        if(ModelState.IsValid){
            peliculaPrevia.Titulo = pelicula.Titulo;
            peliculaPrevia.Genero = pelicula.Genero;
            peliculaPrevia.Anio = pelicula.Anio;
            peliculaPrevia.Descripcion = pelicula.Descripcion;
            //peliculaPrevia.Fecha_Actualizacion = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Peliculas");
        }
        return View("FormularioEditarPelicula", peliculaPrevia);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
