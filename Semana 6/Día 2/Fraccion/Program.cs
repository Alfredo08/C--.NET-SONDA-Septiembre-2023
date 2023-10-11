class Program{
    public static void Main(string[] args){
        Fraccion fraccion1 = new Fraccion(2, 3);
        Fraccion fraccion2 = new Fraccion(1, 4);

        fraccion1.ImprimeFraccion();
        fraccion2.ImprimeFraccion();

        Fraccion fraccion3 = fraccion1.SumaFracciones(fraccion2);
        fraccion3.ImprimeFraccion();

        fraccion3 = fraccion1.MultiplicaFracciones(fraccion2);
        fraccion3.ImprimeFraccion();
    }
}