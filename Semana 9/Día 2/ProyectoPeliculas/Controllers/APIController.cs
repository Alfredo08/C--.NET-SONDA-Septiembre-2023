#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using ProyectoPeliculas.Models;

namespace ProyectoPeliculas.Controllers;

public class APIController : Controller{

    private readonly ILogger<APIController> _logger;
    private MyContext _context;

    public APIController(ILogger<APIController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("api/directores")]
    public JsonResult APIDirectores(){
         List<Director> ListaDirectores = _context.Directores.Include(dir => dir.ListaPeliculas).ToList();
        return Json(ListaDirectores);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
