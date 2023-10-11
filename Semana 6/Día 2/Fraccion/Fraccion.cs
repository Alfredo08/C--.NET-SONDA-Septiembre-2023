class Fraccion{
    private int Numerador;
    public int _Numerador{
        get{ return Numerador; }
        set{ Numerador = value; }
    }
    private int Denominador;
    public int _Denominador{
        get{ return Denominador; }
        set{ Denominador = value; }
    }

    public Fraccion(int n, int d){
        Numerador = n;
        Denominador = d;
    }

    public void ImprimeFraccion(){
        Console.WriteLine($"{Numerador}/{Denominador}");
    }

    public Fraccion SumaFracciones(Fraccion fraccionASumar){
        int nuevoNum = Numerador * fraccionASumar._Denominador + fraccionASumar._Numerador * Denominador;
        int nuevoDen = Denominador * fraccionASumar._Denominador;
        return new Fraccion(nuevoNum, nuevoDen);
    }

    public Fraccion MultiplicaFracciones(Fraccion fraccionAMultiplicar){
        int nuevoNum = Numerador * fraccionAMultiplicar._Numerador;
        int denNuevo = Denominador * fraccionAMultiplicar._Denominador;
        return new Fraccion(nuevoNum, denNuevo);
    }
}