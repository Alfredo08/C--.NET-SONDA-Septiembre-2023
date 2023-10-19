#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProyectoPeliculas.Models;

public class Director{
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    public int Id {get; set;}

    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [MinLength(3, ErrorMessage="Tu nombre debe de tener al menos 3 letras.")]
    public string Nombre {get; set;}
    
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [MinLength(3, ErrorMessage="Tu apellido debe de tener al menos 3 letras.")]
    public string Apellido {get; set;}
    
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [EmailAddress(ErrorMessage="Por favor proporciona un correo válido.")]
    public string Email {get; set;}
    
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [DataType(DataType.Password)]
    public string Password {get; set;}
}