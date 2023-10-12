
public class Estudiante : Persona{
    private string Curso;
    public string _Curso{
        get { return Curso; }
        set { Curso = value; }
    }
    private double Calificacion;
    public double _Calificacion{
        get{ return Calificacion; }
        set{ Calificacion = value; }
    }
    private int Matricula;
    public int _Matricula{
        get{ return Matricula; }
        set{ Matricula = value; }
    }

    public Estudiante(string nom, string ape, int edad, string curso, double cal, int mat) : base(nom, ape, edad){
        Curso = curso;
        Calificacion = cal;
        Matricula = mat;
    }

    public void ImprimeEstudiante(){
        base.ImprimeInformacion();
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Calificación: {Calificacion}");
    }

    public string ImprimeEstudiante(int n){
        string mensaje = $"Nombre: {base._Nombre} {base._Apellido}\nEdad: {base._Edad}\n";
        mensaje += $"Matrícula: {Matricula}\nCurso: {Curso}\nCalificación: {Calificacion}";
        return mensaje;
    }

    public override void ImprimeInformacion(){
        Console.WriteLine($"Datos base: {base._Nombre} {base._Apellido} {base._Edad}");
        Console.WriteLine($"Datos estudiante: {Curso} {Calificacion} {Matricula}");
    }



}