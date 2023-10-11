class Libro{
    // Atributos
    private string Titulo;
    public string _Titulo{
        get { return Titulo; }
        set { Titulo = value; }
    }
    private List<string> Autores = new List<string>();
    private int NumPaginas;
    private int Capitulos;

    // Constructor
    public Libro(string titulo, List<string> autores, int numPaginas, int capitulos){
        Titulo = titulo;
        Autores = autores;
        NumPaginas = numPaginas;
        Capitulos = capitulos;
    }

    // Métodos
    public void ImprimeInformacion(){
        Console.WriteLine($"Titulo: {Titulo}");
        Console.WriteLine("Autores");
        foreach(string autor in Autores){
            Console.WriteLine(autor);
        }
        Console.WriteLine($"Número de páginas: {NumPaginas}");
        Console.WriteLine($"Capitulos: {Capitulos}");
    }
}