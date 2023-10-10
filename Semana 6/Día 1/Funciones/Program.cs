

static int SumaDosNumeros(int num1, int num2){
    int total = num1 + num2;
    return total;
}

static void ImprimeHola(string nombre = "Martha"){
    Console.WriteLine($"¡Hola, cómo estas {nombre}!");
}

int resultado = SumaDosNumeros(20, 30);
Console.WriteLine(resultado);

ImprimeHola("Alex");
ImprimeHola();