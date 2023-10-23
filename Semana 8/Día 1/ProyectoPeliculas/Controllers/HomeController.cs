#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoPeliculas.Models;

namespace ProyectoPeliculas.Controllers;

public class HomeController : Controller{
    public static List<Director> ListaDirectores = new List<Director>();

    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        List<Pelicula> ListaPeliculas = _context.Peliculas.ToList();
        return View("Index", ListaPeliculas);
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
                                            /* SELECT *
                                               FROM directores; */
        List<Director> ListaDirectoresLINQ = _context.Directores.ToList();
        return View("Directores", ListaDirectoresLINQ);
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

    [HttpGet]
    [Route("formulario/pelicula")]
    public IActionResult FormularioPelicula(){
        string? email = HttpContext.Session.GetString("Email");
        if(email == null){
            return View("Login");
        }
        return View("FormularioPelicula");
    }

    [HttpGet]
    [Route("formulario/editar/pelicula/{id_pelicula}")]
    public IActionResult FormularioEditarPelicula(int id_pelicula){
        Pelicula? pelicula = _context.Peliculas.FirstOrDefault(peli => peli.Id == id_pelicula);
        return View("FormularioEditarPelicula", pelicula);
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
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("FormularioPelicula");
    }

    [HttpPost]
    [Route("elimina/pelicula/{id_pelicula}")]
    public IActionResult EliminaPelicula(int id_pelicula){
        Pelicula? pelicula = _context.Peliculas.FirstOrDefault(peli => peli.Id == id_pelicula);
        _context.Peliculas.Remove(pelicula);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("actualiza/pelicula/{id_pelicula}")]
    public IActionResult ActualizaPelicula(Pelicula pelicula, int id_pelicula){
        if(ModelState.IsValid){
            Console.WriteLine("Validaciones exitosas.");
            Pelicula? peliculaPrevia = _context.Peliculas.FirstOrDefault(peli => peli.Id == id_pelicula);

            peliculaPrevia.Titulo = pelicula.Titulo;
            peliculaPrevia.Genero = pelicula.Genero;
            peliculaPrevia.Anio = pelicula.Anio;
            peliculaPrevia.Descripcion = pelicula.Descripcion;
            //peliculaPrevia.Fecha_Actualizacion = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        Console.WriteLine("Algo falló.");
        return View("FormularioEditarPelicula", pelicula);

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
            List<Director> ListaDirectoresLINQ = _context.Directores.ToList();
            foreach(Director director in ListaDirectoresLINQ){
                if(director.Email == login.Email && director.Password == login.Password){
                    HttpContext.Session.SetString("Nombre", director.Nombre);
                    HttpContext.Session.SetString("Apellido", director.Apellido);
                    HttpContext.Session.SetString("Email", director.Email);
                    HttpContext.Session.SetInt32("Id", director.Id);
                    return RedirectToAction("Index");
                }
            }
            // Falta enviar mensaje de error "Credenciales incorrectas"
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
