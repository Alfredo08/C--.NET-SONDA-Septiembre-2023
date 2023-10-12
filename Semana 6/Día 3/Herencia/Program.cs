
Persona alex = new Persona("Alex", "Miller", 25);
Persona martha = new Persona("Martha", "Gómez", 23);
Persona miguel = new Persona();

alex.ImprimeInformacion();
martha.ImprimeInformacion();
miguel.ImprimeInformacion();

Estudiante roger = new Estudiante("Roger", "Anderson", 24, "Fundamentos de la Web", 9.8, 63548);
roger.ImprimeEstudiante();

string mensaje = roger.ImprimeEstudiante(10);
Console.WriteLine(mensaje);