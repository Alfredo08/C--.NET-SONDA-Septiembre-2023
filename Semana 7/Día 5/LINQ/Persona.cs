
public class Persona{
    public string? Nombre {get; set;}
    public string? Apellido {get; set;}
    public int Edad {get; set;}

    public void ImprimeInformacion(){
        Console.WriteLine($"Nombre: {this.Nombre}");
        Console.WriteLine($"Apellido: {this.Apellido}");
        Console.WriteLine($"Edad: {this.Edad}");
    }
}