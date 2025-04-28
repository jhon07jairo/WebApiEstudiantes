using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "EstudianteId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Juan Pérez" },
                    { 2, "María López" }
                });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "ProfesorId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ana Torres" },
                    { 2, "Carlos Gómez" },
                    { 3, "Laura Sánchez" },
                    { 4, "Miguel Ángel" },
                    { 5, "Patricia Ramírez" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "MateriaId", "Creditos", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { 1, 3, "Matemáticas", 1 },
                    { 2, 3, "Estadística", 1 },
                    { 3, 3, "Física", 2 },
                    { 4, 3, "Química", 2 },
                    { 5, 3, "Historia", 3 },
                    { 6, 3, "Literatura", 3 },
                    { 7, 3, "Programación", 4 },
                    { 8, 3, "Bases de Datos", 4 },
                    { 9, 3, "Inglés", 5 },
                    { 10, 3, "Francés", 5 }
                });

            migrationBuilder.InsertData(
                table: "EstudianteMaterias",
                columns: new[] { "EstudianteId", "MateriaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "EstudianteMaterias",
                keyColumns: new[] { "EstudianteId", "MateriaId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "EstudianteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "ProfesorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "ProfesorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "ProfesorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "ProfesorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "ProfesorId",
                keyValue: 4);
        }
    }
}
