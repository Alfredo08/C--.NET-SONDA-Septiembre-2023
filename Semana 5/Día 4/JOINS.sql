SELECT *
FROM directores
WHERE email LIKE '%@m%';

SELECT *
FROM peliculas;

SELECT peliculas.id, titulo, genero, anio, nombre, apellido 
FROM directores JOIN peliculas
	ON directores.id = peliculas.director_id
WHERE nombre = 'Alex' AND apellido = 'Miller';

SELECT *
FROM directores, peliculas
WHERE directores.id = peliculas.director_id AND nombre = 'Alex' AND apellido = 'Miller';

SELECT id AS identificador, CONCAT(nombre, ' ', apellido) AS nombre_completo, email AS correo
FROM directores
ORDER BY nombre DESC;


SELECT *
FROM directores LEFT JOIN peliculas 
	ON directores.id = peliculas.director_id;
    
SELECT nombre, apellido, COUNT(directores.id) AS num_de_peliculas
FROM directores JOIN peliculas
	ON directores.id = director_id
GROUP BY directores.id;

