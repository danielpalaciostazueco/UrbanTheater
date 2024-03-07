using System;
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
                name: "Asientos",
                columns: table => new
                {
                    idAsiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.idAsiento);
                });

            migrationBuilder.CreateTable(
                name: "AsientosObrasDatos",
                columns: table => new
                {
                    idObjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idObra = table.Column<int>(type: "int", nullable: false),
                    idSesion = table.Column<int>(type: "int", nullable: false),
                    idAsiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientosObrasDatos", x => x.idObjeto);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Actores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaUno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTres = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cartel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "idAsiento", "isFree" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true },
                    { 3, true },
                    { 4, true },
                    { 5, true },
                    { 6, true },
                    { 7, true },
                    { 8, true },
                    { 9, true },
                    { 10, true },
                    { 11, true },
                    { 12, true },
                    { 13, true },
                    { 14, true },
                    { 15, true },
                    { 16, true },
                    { 17, true },
                    { 18, true },
                    { 19, true },
                    { 20, true }
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "Actores", "Autores", "Cartel", "Descripcion", "Duracion", "FechaDos", "FechaTres", "FechaUno", "Imagenes", "Nombre" },
                values: new object[,]
                {
                    { 1, "Alexander Montgomery, Isabella Ramirez, Benjamin Worthington, Olivia Hawthorne, Nathaniel Harrington", "Samuel Beckett", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot.jpg", "Una obra teatral absurda que sigue a dos personajes, Vladimir y Estragon, mientras esperan en un lugar desolado a alguien llamado Godot, explorando temas de la existencia, la alienación y la esperanza.", 7200, new DateTime(2024, 3, 9, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot_FN.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/esperando-a-godot_FN2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Esperando-Godot/una-escena-de-esperando-a-godot.jpg", "Esperando a Godot" },
                    { 2, "Sophia Anderson, Daniel Blackwood, Elena Rodriguez, Nicholas Smith, Isabella Johnson ", "Andrew Lloyd Webber, Charles Hart, Richard Stilgoe", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/fantasma-opera.jpg", "Una icónica obra de teatro musical que narra la historia de un misterioso y desfigurado hombre conocido como el Fantasma, que vive en los pasadizos de la Ópera de París y se obsesiona con una joven y talentosa soprano, Christine.", 4800, new DateTime(2024, 1, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/fantasma-opera_FN.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Fantasma-opera/Fantasma-operea_FN2.jpg", "El Fantasma de la Ópera" },
                    { 3, "Miguel Ángel Jiménez, Laura González, José Martín, Carmen Sánchez, Diego Torres", "Valentina Moreno, Carlos Ruiz", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/Galder.jpeg", "Un audaz espectáculo que desafía las convenciones, combinando elementos de teatro, danza y performance art. La trama sigue a un grupo ecléctico de artistas mientras exploran temas de identidad, realidad y percepción a través de actuaciones vanguardistas.", 9000, new DateTime(2024, 5, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/galder2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Galder/galder3.jpg", "Esto No Es Un Show" },
                    { 4, "Alexander Knight, Sarah Miller, David Johnson, Emily White, Richard Brown", "William Shakespeare", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet.jpg", "Una de las tragedias más emblemáticas de William Shakespeare, centrada en la historia del príncipe Hamlet de Dinamarca, quien busca vengar la muerte de su padre. La obra explora temas complejos como la locura, la traición, la venganza y la moralidad.", 6300, new DateTime(2024, 6, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet_FN2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Hamlet/hamlet_FN.jpg", "Hamlet" },
                    { 5, "Michael James, Elizabeth Green, Thomas Hill, Rachel Adams, William Parker", "Irene Mecchi, Jonathan Roberts, Linda Woolverton", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyLeon.webp", "Un musical espectacular basado en la famosa película animada de Disney. La historia sigue las aventuras de Simba, un joven león que debe enfrentar numerosos desafíos para reclamar su lugar como el legítimo rey de la sabana. El musical es conocido por su impresionante uso de disfraces, marionetas y efectos visuales para recrear el ambiente de África.", 4800, new DateTime(2024, 7, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyleonIMG3.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyLeonImg1.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/Rey-Leon/reyleonIMG2.avif", "El Rey León" },
                    { 6, "Elena Sánchez, Carlos Pérez, María López, José Torres, Laura Jiménez", "Ana García, Luis Hernández", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre.jpg", "Una comedia romántica contemporánea que sigue la historia de varias parejas que se preparan para sus respectivas bodas. La obra teje una trama llena de enredos amorosos, malentendidos cómicos y momentos de reflexión sobre las relaciones y el matrimonio.", 9000, new DateTime(2024, 8, 12, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre_NF2.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/BodasDeSangre/BodasDeSangre_NF.jpg", "Bodas de sangre" },
                    { 7, "Augusto González, Fernando Ardévol, Juan Luis García", "Alberto Marca, Carlos Marco", "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b-vocal_LG.jpg", "Un aclamado grupo vocal que destaca por su habilidad para fusionar a cappella y comedia en sus actuaciones. B-Vocal cautiva al público con su mezcla única de música, humor y la sorprendente habilidad de crear sonidos instrumentales con sus voces, explorando diversos géneros musicales desde el pop hasta el clásico.", 7200, new DateTime(2024, 9, 3, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b-vocal_NF.jpg , https://ik.imagekit.io/daniel2003/fotos-descripción-obras-teatro/B-vocal/b.jpg", "B-Vocal" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "contrasena", "nombreUsuario", "rol" },
                values: new object[] { 1, "Daniel_Admin123", "Daniel_Admin", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "AsientosObrasDatos");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
