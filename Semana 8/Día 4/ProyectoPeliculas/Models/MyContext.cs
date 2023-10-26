#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ProyectoPeliculas.Models;

public class MyContext : DbContext {   

    public DbSet<Director> Directores { get; set; } 

    public DbSet<Pelicula> Peliculas { get; set; } 

    public MyContext(DbContextOptions options) : base(options) { }    
}