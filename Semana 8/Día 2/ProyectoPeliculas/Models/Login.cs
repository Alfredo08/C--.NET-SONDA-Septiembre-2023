#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProyectoPeliculas.Models;

public class Login{
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [EmailAddress(ErrorMessage="Por favor proporciona un correo válido.")]
    public string Email {get; set;}
    
    [Required(ErrorMessage="Por favor proporciona este dato!")]
    [DataType(DataType.Password)]
    public string Password {get; set;}
}