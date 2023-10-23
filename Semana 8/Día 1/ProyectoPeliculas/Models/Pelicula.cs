#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProyectoPeliculas.Models;

public class Pelicula{
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [MinLength(3, ErrorMessage="Por favor proporciona este dato!")]
    public string Titulo {get; set;}

    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [MinLength(3, ErrorMessage="Por favor proporciona este dato!")]
    public string Genero {get; set;}

    [Required(ErrorMessage="Por favor proporciona este dato!")]
    public int Anio {get; set;}

    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [MinLength(3, ErrorMessage="Por favor proporciona este dato!")]
    public string Descripcion {get; set;}

    public int Director_Id {get; set;}

    public DateTime Fecha_Creacion {get; set;} = DateTime.Now;

    public DateTime Fecha_Actualizacion {get; set;} = DateTime.Now;

}