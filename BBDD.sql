CREATE DATABASE UrbanTheaterDB
use UrbanTheaterDB

CREATE TABLE Obras (
    ObraID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion TEXT,
    Autores NVARCHAR(255), 
    Duracion DECIMAL(3, 1),
    Actores NVARCHAR(MAX), 
    Imagenes NVARCHAR(MAX), 
    Fechas NVARCHAR(MAX), 
    Slug NVARCHAR(100),
    Cartel NVARCHAR(255)
);

-- Insertar 'Esperando a Godot'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('Esperando a Godot', 'Una obra teatral absurda que sigue a dos personajes, Vladimir y Estragon, mientras esperan en un lugar desolado a alguien llamado Godot, explorando temas de la existencia, la alienación y la esperanza.', 'Samuel Beckett', 2, 'Alexander Montgomery,Isabella Ramirez,Benjamin Worthington,Olivia Hawthorne,Nathaniel Harrington', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot_FN.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot_FN2.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/una-escena-de-esperando-a-godot.jpg', '2024-03-03 - 21:00,2024-03-09 - 22:00,2024-03-18 - 23:00', 'godot', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot.jpg');

-- Insertar 'El Fantasma de la Ópera'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('El Fantasma de la Ópera', 'Una icónica obra de teatro musical que narra la historia de un misterioso y desfigurado hombre conocido como el Fantasma, que vive en los pasadizos de la Ópera de París y se obsesiona con una joven y talentosa soprano, Christine.', 'Andrew Lloyd Webber', 2.5, 'Sophia Anderson,Daniel Blackwood,Elena Rodriguez,Nicholas Smith,Isabella Johnson', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/fantasma-opera_FN.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/Fantasma-operea_FN2.jpg', '2024-01-07 - 20:30,2024-01-12 - 21:00,2024-01-22 - 19:00', 'fantasma', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/fantasma-opera.jpg');

-- Insertar 'Esto No Es Un Show'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('Esto No Es Un Show', 'Un audaz espectáculo que desafía las convenciones, combinando elementos de teatro, danza y performance art. La trama sigue a un grupo ecléctico de artistas mientras exploran temas de identidad, realidad y percepción a través de actuaciones vanguardistas.', 'Valentina Moreno,Carlos Ruiz', 1.75, 'Miguel Ángel Jiménez,Laura González,José Martín,Carmen Sánchez,Diego Torres', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/galder2.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/galder3.jpg', '2024-05-01 - 23:00,2024-05-15 - 22:00,2024-05-20 - 21:00', 'show', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/Galder.jpeg');

-- Insertar 'Hamlet'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('Hamlet', 'Una de las tragedias más emblemáticas de William Shakespeare, centrada en la historia del príncipe Hamlet de Dinamarca, quien busca vengar la muerte de su padre. La obra explora temas complejos como la locura, la traición, la venganza y la moralidad.', 'William Shakespeare', 3, 'Alexander Knight,Sarah Miller,David Johnson,Emily White,Richard Brown', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet_FN2.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet_FN.jpg', '2024-06-01 - 18:30,2024-06-06 - 19:00,2024-06-10 - 22:00', 'hamlet', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet.jpg');

-- Insertar 'El Rey León'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('El Rey León', 'Un musical espectacular basado en la famosa película animada de Disney. La historia sigue las aventuras de Simba, un joven león que debe enfrentar numerosos desafíos para reclamar su lugar como el legítimo rey de la sabana. El musical es conocido por su impresionante uso de disfraces, marionetas y efectos visuales para recrear el ambiente de África.', 'Irene Mecchi,Jonathan Roberts,Linda Woolverton', 2.5, 'Michael James,Elizabeth Green,Thomas Hill,Rachel Adams,William Parker', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyleonIMG3.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyLeonImg1.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyleonIMG2.avif', '2024-07-01 - 21:00,2024-07-10 - 19:00,2024-07-20 - 20:00', 'leon', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyLeon.webp');

-- Insertar 'Bodas de sangre'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('Bodas de sangre', 'Una comedia romántica contemporánea que sigue la historia de varias parejas que se preparan para sus respectivas bodas. La obra teje una trama llena de enredos amorosos, malentendidos cómicos y momentos de reflexión sobre las relaciones y el matrimonio.', 'Ana García,Luis Hernández', 2, 'Elena Sánchez,Carlos Pérez,María López,José Torres,Laura Jiménez', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre_NF2.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre_NF.jpg', '2024-08-02 - 21:00,2024-08-12 - 20:00,2024-08-21 - 21:00', 'bodas', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre.jpg');

-- Insertar 'B-Vocal'
INSERT INTO Obras (Nombre, Descripcion, Autores, Duracion, Actores, Imagenes, Fechas, Slug, Cartel) VALUES
('B-Vocal', 'Un aclamado grupo vocal que destaca por su habilidad para fusionar a cappella y comedia en sus actuaciones. B-Vocal cautiva al público con su mezcla única de música, humor y la sorprendente habilidad de crear sonidos instrumentales con sus voces, explorando diversos géneros musicales desde el pop hasta el clásico.', 'Alberto Marca,Carlos Marco', 1.5, 'Augusto González,Fernando Ardévol,Juan Luis García', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b-vocal_NF.jpg,https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b.jpg', '2024-09-01 - 21:00,2024-09-03 - 22:30,2024-09-10 - 23:00', 'vocal', 'https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b-vocal_LG.jpg');
