
Dictionary<string, string> perfil = new Dictionary<string, string>();

perfil.Add("Nombre", "Alex");
perfil.Add("Apellido", "Miller");
perfil.Add("Edad", "25");
perfil.Add("Curso", "C#/.NET");

Console.WriteLine(perfil["Edad"]);

foreach(var renglon in perfil){
    Console.WriteLine(renglon.Key + " - " + renglon.Value);
}

Console.WriteLine("-----");

foreach(KeyValuePair<string, string> renglon in perfil){
    Console.WriteLine(renglon.Key + " - " + renglon.Value);
}