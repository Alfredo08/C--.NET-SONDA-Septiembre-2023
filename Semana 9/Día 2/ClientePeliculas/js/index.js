
const cargarListaDirectores = async (elemento) =>{
    const URL = "http://localhost:5003/api/directores";
    
    const response = await fetch(URL);
    const datos = await response.json();
    const resultados = document.querySelector('.resultados');
    resultados.innerHTML = "";

    datos.forEach(director => {
        let informacionPeliculas = "";
        director.listaPeliculas.forEach(pelicula => {
            informacionPeliculas += `
                <li>
                    ${pelicula.titulo} - ${pelicula.genero}
                </li>
            `;
        });

        resultados.innerHTML += `
            <div class="director">
                <h2> ${director.nombre} ${director.apellido} </h2>
                <p> ${director.email}</p>
                <ul class="peliculas">
                    ${informacionPeliculas}
                </ul>
            </div>
        `;
    })
}