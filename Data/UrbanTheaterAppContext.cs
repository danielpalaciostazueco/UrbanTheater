using Microsoft.EntityFrameworkCore;
using UrbanTheater.Models;
namespace UrbanTheater.Data
{
    public class UrbanTheaterAppContext : DbContext
    {
        public UrbanTheaterAppContext(DbContextOptions<UrbanTheaterAppContext> options)
            : base(options)
        {
        }

        public DbSet<Obra> Obras { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<AsientosObrasDatos> AsientosObrasDatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historial> Historial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obra>().HasData(
                   new Obra
                   {
                       ObraID = 1,
                       Nombre = "Esperando a Godot",
                       Descripcion = "Una obra teatral absurda que sigue a dos personajes, Vladimir y Estragon, mientras esperan en un lugar desolado a alguien llamado Godot, explorando temas de la existencia, la alienación y la esperanza.",
                       Autores = "Samuel Beckett",
                       Duracion = 120,
                       Actores = "Alexander Montgomery, Isabella Ramirez, Benjamin Worthington, Olivia Hawthorne, Nathaniel Harrington",
                       Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot_FN.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot_FN2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/una-escena-de-esperando-a-godot.jpg",
                       FechaUno = new DateTime(2024, 3, 3, 21, 0, 0),
                       FechaDos = new DateTime(2024, 3, 9, 22, 0, 0),
                       FechaTres = new DateTime(2024, 3, 18, 23, 0, 0),
                       Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot.jpg"
                   },
                   new Obra
                   {
                       ObraID = 2,
                       Nombre = "El Fantasma de la Ópera",
                       Descripcion = "Una icónica obra de teatro musical que narra la historia de un misterioso y desfigurado hombre conocido como el Fantasma, que vive en los pasadizos de la Ópera de París y se obsesiona con una joven y talentosa soprano, Christine.",
                       Autores = "Andrew Lloyd Webber, Charles Hart, Richard Stilgoe",
                       Duracion = 80,
                       Actores = "Sophia Anderson, Daniel Blackwood, Elena Rodriguez, Nicholas Smith, Isabella Johnson ",
                       Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/fantasma-opera_FN.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/Fantasma-operea_FN2.jpg",
                       FechaUno = new DateTime(2024, 1, 7, 20, 30, 0),
                       FechaDos = new DateTime(2024, 1, 12, 21, 0, 0),
                       FechaTres = new DateTime(2024, 1, 22, 19, 0, 0),
                       Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/fantasma-opera.jpg"
                   },
                new Obra
                {
                    ObraID = 3,
                    Nombre = "Esto No Es Un Show",
                    Descripcion = "Un audaz espectáculo que desafía las convenciones, combinando elementos de teatro, danza y performance art. La trama sigue a un grupo ecléctico de artistas mientras exploran temas de identidad, realidad y percepción a través de actuaciones vanguardistas.",
                    Autores = "Valentina Moreno, Carlos Ruiz",
                    Duracion = 150,
                    Actores = "Miguel Ángel Jiménez, Laura González, José Martín, Carmen Sánchez, Diego Torres",
                    Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/galder2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/galder3.jpg",
                    FechaUno = new DateTime(2024, 5, 1, 23, 0, 0),
                    FechaDos = new DateTime(2024, 5, 15, 22, 0, 0),
                    FechaTres = new DateTime(2024, 5, 20, 21, 0, 0),
                    Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/Galder.jpeg"
                },
                   new Obra
                   {
                       ObraID = 4,
                       Nombre = "Hamlet",
                       Descripcion = "Una de las tragedias más emblemáticas de William Shakespeare, centrada en la historia del príncipe Hamlet de Dinamarca, quien busca vengar la muerte de su padre. La obra explora temas complejos como la locura, la traición, la venganza y la moralidad.",
                       Autores = "William Shakespeare",
                       Duracion = 105,
                       Actores = "Alexander Knight, Sarah Miller, David Johnson, Emily White, Richard Brown",
                       Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet_FN2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet_FN.jpg",
                       FechaUno = new DateTime(2024, 6, 1, 18, 30, 0),
                       FechaDos = new DateTime(2024, 6, 6, 19, 0, 0),
                       FechaTres = new DateTime(2024, 6, 10, 22, 0, 0),
                       Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet.jpg"
                   },
                new Obra
                {
                    ObraID = 5,
                    Nombre = "El Rey León",
                    Descripcion = "Un musical espectacular basado en la famosa película animada de Disney. La historia sigue las aventuras de Simba, un joven león que debe enfrentar numerosos desafíos para reclamar su lugar como el legítimo rey de la sabana. El musical es conocido por su impresionante uso de disfraces, marionetas y efectos visuales para recrear el ambiente de África.",
                    Autores = "Irene Mecchi, Jonathan Roberts, Linda Woolverton",
                    Duracion = 80,
                    Actores = "Michael James, Elizabeth Green, Thomas Hill, Rachel Adams, William Parker",
                    Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyleonIMG3.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyLeonImg1.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyleonIMG2.avif",
                    FechaUno = new DateTime(2024, 7, 1, 21, 0, 0),
                    FechaDos = new DateTime(2024, 7, 10, 19, 0, 0),
                    FechaTres = new DateTime(2024, 7, 20, 20, 0, 0),
                    Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyLeon.webp"
                },
                new Obra
                {
                    ObraID = 6,
                    Nombre = "Bodas de sangre",
                    Descripcion = "Una comedia romántica contemporánea que sigue la historia de varias parejas que se preparan para sus respectivas bodas. La obra teje una trama llena de enredos amorosos, malentendidos cómicos y momentos de reflexión sobre las relaciones y el matrimonio.",
                    Autores = "Ana García, Luis Hernández",
                    Duracion = 150,
                    Actores = "Elena Sánchez, Carlos Pérez, María López, José Torres, Laura Jiménez",
                    Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre_NF2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre_NF.jpg",
                    FechaUno = new DateTime(2024, 8, 2, 21, 0, 0),
                    FechaDos = new DateTime(2024, 8, 12, 20, 0, 0),
                    FechaTres = new DateTime(2024, 8, 21, 21, 0, 0),
                    Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre.jpg"
                },
                new Obra
                {
                    ObraID = 7,
                    Nombre = "B-Vocal",
                    Descripcion = "Un aclamado grupo vocal que destaca por su habilidad para fusionar a cappella y comedia en sus actuaciones. B-Vocal cautiva al público con su mezcla única de música, humor y la sorprendente habilidad de crear sonidos instrumentales con sus voces, explorando diversos géneros musicales desde el pop hasta el clásico.",
                    Autores = "Alberto Marca, Carlos Marco",
                    Duracion = 120,
                    Actores = "Augusto González, Fernando Ardévol, Juan Luis García",
                    Imagenes = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b-vocal_NF.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b.jpg",
                    FechaUno = new DateTime(2024, 9, 1, 21, 0, 0),
                    FechaDos = new DateTime(2024, 9, 3, 22, 30, 0),
                    FechaTres = new DateTime(2024, 9, 10, 23, 0, 0),
                    Cartel = "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b-vocal_LG.jpg"
                }

           );
            modelBuilder.Entity<Asiento>().HasData(
                new Asiento
                {
                    idAsiento = 1,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 2,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 3,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 4,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 5,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 6,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 7,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 8,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 9,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 10,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 11,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 12,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 13,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 14,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 15,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 16,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 17,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 18,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 19,
                    isFree = true
                },
                new Asiento
                {
                    idAsiento = 20,
                    isFree = true
                }
            );
            modelBuilder.Entity<Usuario>().HasData(
                 new Usuario
                 {
                     idUsuario = 1,
                     nombreUsuario = "Daniel_Admin",
                     contrasena = "Daniel_Admin123",
                     rol = 1
                 }

             );
        }
    }
}
