using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrbanTheater.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Actores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fechas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cartel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraID);
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "Actores", "Autores", "Cartel", "Descripcion", "Duracion", "Fechas", "Imagenes", "Nombre", "Slug" },
                values: new object[,]
                {
                    { 1, "[\"Alexander Montgomery\",\"Isabella Ramirez\",\"Benjamin Worthington\",\"Olivia Hawthorne\",\"Nathaniel Harrington\"]", "[\"Samuel Beckett\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot.jpg", "Una obra teatral absurda que sigue a dos personajes, Vladimir y Estragon, mientras esperan en un lugar desolado a alguien llamado Godot, explorando temas de la existencia, la alienación y la esperanza.", 2m, "[\"2024-03-03 - 21:00\",\"2024-03-09 - 22:00\",\"2024-03-18 - 23:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot_FN.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/esperando-a-godot_FN2.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Esperando-Godot/una-escena-de-esperando-a-godot.jpg\"]", "Esperando a Godot", "godot" },
                    { 2, "[\"Sophia Anderson\",\"Daniel Blackwood\",\"Elena Rodriguez\",\"Nicholas Smith\",\"Isabella Johnson\"]", "[\"Andrew Lloyd Webber\",\"Charles Hart\",\"Richard Stilgoe\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/fantasma-opera.jpg", "Una icónica obra de teatro musical que narra la historia de un misterioso y desfigurado hombre conocido como el Fantasma, que vive en los pasadizos de la Ópera de París y se obsesiona con una joven y talentosa soprano, Christine.", 2.5m, "[\"2024-01-07 - 20:30\",\"2024-01-12 - 21:00\",\"2024-01-22 - 19:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/fantasma-opera_FN.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Fantasma-opera/Fantasma-operea_FN2.jpg\"]", "El Fantasma de la Ópera", "fantasma" },
                    { 3, "[\"Miguel \\u00C1ngel Jim\\u00E9nez\",\"Laura Gonz\\u00E1lez\",\"Jos\\u00E9 Mart\\u00EDn\",\"Carmen S\\u00E1nchez\",\"Diego Torres\"]", "[\"Valentina Moreno\",\"Carlos Ruiz\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/Galder.jpeg", "Un audaz espectáculo que desafía las convenciones, combinando elementos de teatro, danza y performance art. La trama sigue a un grupo ecléctico de artistas mientras exploran temas de identidad, realidad y percepción a través de actuaciones vanguardistas.", 1.75m, "[\"2024-05-01 - 23:00\",\"2024-05-15 - 22:00\",\"2024-05-20 - 21:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/galder2.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Galder/galder3.jpg\"]", "Esto No Es Un Show", "show" },
                    { 4, "[\"Alexander Knight\",\"Sarah Miller\",\"David Johnson\",\"Emily White\",\"Richard Brown\"]", "[\"William Shakespeare\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet.jpg", "Una de las tragedias más emblemáticas de William Shakespeare, centrada en la historia del príncipe Hamlet de Dinamarca, quien busca vengar la muerte de su padre. La obra explora temas complejos como la locura, la traición, la venganza y la moralidad.", 3m, "[\"2024-06-01 - 18:30\",\"2024-06-06 - 19:00\",\"2024-06-10 - 22:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet_FN2.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Hamlet/hamlet_FN.jpg\"]", "Hamlet", "hamlet" },
                    { 5, "[\"Michael James\",\"Elizabeth Green\",\"Thomas Hill\",\"Rachel Adams\",\"William Parker\"]", "[\"Irene Mecchi\",\"Jonathan Roberts\",\"Linda Woolverton\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyLeon.webp", "Un musical espectacular basado en la famosa película animada de Disney. La historia sigue las aventuras de Simba, un joven león que debe enfrentar numerosos desafíos para reclamar su lugar como el legítimo rey de la sabana. El musical es conocido por su impresionante uso de disfraces, marionetas y efectos visuales para recrear el ambiente de África.", 2.5m, "[\"2024-07-01 - 21:00\",\"2024-07-10 - 19:00\",\"2024-07-20 - 20:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyleonIMG3.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyLeonImg1.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/Rey-Leon/reyleonIMG2.avif\"]", "El Rey León", "leon" },
                    { 6, "[\"Elena S\\u00E1nchez\",\"Carlos P\\u00E9rez\",\"Mar\\u00EDa L\\u00F3pez\",\"Jos\\u00E9 Torres\",\"Laura Jim\\u00E9nez\"]", "[\"Ana Garc\\u00EDa\",\"Luis Hern\\u00E1ndez\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre.jpg", "Una comedia romántica contemporánea que sigue la historia de varias parejas que se preparan para sus respectivas bodas. La obra teje una trama llena de enredos amorosos, malentendidos cómicos y momentos de reflexión sobre las relaciones y el matrimonio.", 2m, "[\"2024-08-02 - 21:00\",\"2024-08-12 - 20:00\",\"2024-08-21 - 21:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre_NF2.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/BodasDeSangre/BodasDeSangre_NF.jpg\"]", "Bodas de sangre", "bodas" },
                    { 7, "[\"Augusto Gonz\\u00E1lez\",\"Fernando Ard\\u00E9vol\",\"Juan Luis Garc\\u00EDa\"]", "[\"Alberto Marca\",\"Carlos Marco\"]", "https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b-vocal_LG.jpg", "Un aclamado grupo vocal que destaca por su habilidad para fusionar a cappella y comedia en sus actuaciones. B-Vocal cautiva al público con su mezcla única de música, humor y la sorprendente habilidad de crear sonidos instrumentales con sus voces, explorando diversos géneros musicales desde el pop hasta el clásico.", 1.5m, "[\"2024-09-01 - 21:00\",\"2024-09-03 - 22:30\",\"2024-09-10 - 23:00\"]", "[\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b-vocal_NF.jpg\",\"https://ik.imagekit.io/daniel2003/fotos-descripci%C3%B3n-obras-teatro/B-vocal/b.jpg\"]", "B-Vocal", "vocal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
