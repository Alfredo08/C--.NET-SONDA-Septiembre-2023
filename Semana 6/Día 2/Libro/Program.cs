
class Program{
    public static void Main(string[] args){
        string tituloLibro = "El principito";
        List<string> autores = new List<string>();
        autores.Add("Antonio de Saint");
        int numPaginas = 305;
        int capitulos = 15;

        Libro elPrincipito = new Libro(tituloLibro, autores, numPaginas, capitulos);
        elPrincipito.ImprimeInformacion();
        
        tituloLibro = "Don Quijote de la Mancha";
        autores.Remove("Antonio de Saint");
        autores.Add("Miguel de Cervantes");
        numPaginas = 1300;
        capitulos = 55;

        Libro donQuijote = new Libro(tituloLibro, autores, numPaginas, capitulos);
        donQuijote.ImprimeInformacion();

        Console.WriteLine(donQuijote._Titulo);
        donQuijote._Titulo = "Cien años de soledad";
        donQuijote.ImprimeInformacion();
    }
}

