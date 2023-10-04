
INSERT INTO directores(nombre, apellido, email, password)
VALUES ('Alex', 'Miller', 'alex@miller.com', 'password123');

INSERT INTO directores(nombre, apellido, email, password)
VALUES ('Martha', 'Gómez', 'martha@gomez.com', 'password123'),
	   ('Roger', 'Anderson', 'roger@anderson.com', 'password123'),
       ('Julieta', 'Venegas', 'julieta@venegas.com', 'password123');
       
INSERT INTO directores(nombre, apellido, email, password)
VALUES ('Alex', 'Gonzalez', 'alex@gonzalez.com', 'password123'),
	   ('Alex', 'Martinez', 'alex@martinez.com', 'password123');

SELECT *
FROM directores
WHERE nombre = 'Alex' AND apellido = 'Miller';

SELECT id, nombre, apellido, email
FROM directores
WHERE id > 3;

UPDATE directores
SET nombre = 'Alan', apellido = 'Morales', email = 'alan@morales.com'
WHERE id = 2;

DELETE FROM directores
WHERE id = 6;

SELECT *
FROM directores;

INSERT INTO peliculas(titulo, genero, anio, descripcion, director_id)
VALUES ('Shrek', 'Animación', 2000, 'Muy buena película', 4);

INSERT INTO peliculas(titulo, genero, anio, descripcion, director_id)
VALUES ('Toy Story', 'Animación', 1995, 'Excelente película', 1);

SELECT *
FROM peliculas;






