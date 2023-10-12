
public abstract class Figura{
    private int NumLados;
    public int _NumLados{
        get{ return NumLados; }
        set{ NumLados = value; }
    }

    public Figura(int numLados){
        NumLados = numLados;
    }

    public abstract double Area();
    public abstract double Perimetro();
}