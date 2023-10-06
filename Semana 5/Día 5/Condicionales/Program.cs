
/*
> < >= <= != == ! 
|| && 
*/
string nombre = "Alex";
int edad = 16;

if(edad >= 18){
    Console.WriteLine(nombre + " ya puedes manejar.");
}
else{
    int anios = 18 - edad;
    Console.WriteLine(nombre + " te faltan " + anios + " años para poder manejar.");
    Console.WriteLine($"{nombre} te faltan {anios} años para poder manejar.");
}

char num1 = 'D';
int num2 = (int)num1 + 32; // Mirar Codigo ASCII
char resultado = (char)num2;

Console.WriteLine(resultado);

if(num1 == num2){
    Console.WriteLine("Son iguales.");
}
else{
    Console.WriteLine("Son diferentes.");
}


