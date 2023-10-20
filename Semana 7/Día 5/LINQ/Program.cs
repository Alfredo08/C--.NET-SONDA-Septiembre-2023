
List<Persona> ListaPersonas = new List<Persona>(){
    new Persona{
        Nombre = "Alex",
        Apellido = "Miller",
        Edad = 25
    },
    new Persona{
        Nombre = "Martha",
        Apellido = "Gómez",
        Edad = 22
    },
    new Persona{
        Nombre = "Roger",
        Apellido = "Anderson",
        Edad = 28
    }
};

IEnumerable<Persona> MayoresA25 = ListaPersonas.Where(persona => persona.Edad >= 25);

foreach(Persona persona in MayoresA25){
    persona.ImprimeInformacion();
}

Console.WriteLine("-------");

IEnumerable<Persona> OrdenarPorEdad = ListaPersonas.OrderByDescending(persona => persona.Edad);

foreach(Persona persona in OrdenarPorEdad){
    persona.ImprimeInformacion();
}
