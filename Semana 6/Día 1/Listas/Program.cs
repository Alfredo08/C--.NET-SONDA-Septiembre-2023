
List<string> listaNombres = new List<string>();

listaNombres.Add("Alex");
listaNombres.Add("Martha");
listaNombres.Add("Roger");
listaNombres.Add("Alan");
listaNombres.Add("Julieta");

listaNombres.Insert(3, "Maria");

for(int i = 0; i < listaNombres.Count; i ++){
    Console.WriteLine(listaNombres[i]);
}

Console.WriteLine("------");

listaNombres.Remove("Roger");
listaNombres.RemoveAt(1);

foreach(string nombre in listaNombres){
    Console.WriteLine(nombre);
}
