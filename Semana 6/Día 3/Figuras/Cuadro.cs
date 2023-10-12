
public class Cuadro : Figura{
    private double Longitud;
    public double _Longitud{
        get{ return Longitud; }
        set{ Longitud = value; }
    }

    public Cuadro(int numLados, double longitud) : base(numLados){
        Longitud = longitud;
    }

    public override double Area(){
        return Longitud * Longitud;
    }

    public override double Perimetro(){
        return 4 * Longitud;
    }
}