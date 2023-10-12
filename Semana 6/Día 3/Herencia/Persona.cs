public class Persona{
    private string Nombre;
    public string _Nombre{
        get{ return Nombre; }
        set{ Nombre = value; }
    }
    private string Apellido;
    public string _Apellido{
        get{ return Apellido; }
        set{ Apellido = value; }
    }
    private int Edad;
    public int _Edad{
        get{ return Edad; }
        set{ Edad = value; }
    }

    public Persona(){
        Nombre = "No disponible";
        Apellido = "No disponible";
        Edad = -1;
    }

    public Persona(string nombre, string apellido, int edad){
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
    }

    public virtual void ImprimeInformacion(){
        Console.WriteLine("-----");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellido: {Apellido}");
        Console.WriteLine($"Edad: {Edad}");
    }
}