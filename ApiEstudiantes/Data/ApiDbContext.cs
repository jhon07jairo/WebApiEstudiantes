using ApiEstudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiantes.Data
{
	public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
	{
		public DbSet<Estudiante> Estudiantes { get; set; }
		public DbSet<Materia> Materias { get; set; }
		public DbSet<Profesor> Profesores { get; set; }
		public DbSet<EstudianteMateria> EstudianteMaterias { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EstudianteMateria>()
				.HasKey(em => new { em.EstudianteId, em.MateriaId });
			modelBuilder.Entity<EstudianteMateria>()
				.HasOne(em => em.Estudiante)
				.WithMany(e => e.EstudianteMaterias)
				.HasForeignKey(em => em.EstudianteId);
			modelBuilder.Entity<EstudianteMateria>()
				.HasOne(em => em.Materia)
				.WithMany(m => m.EstudianteMaterias)
				.HasForeignKey(em => em.MateriaId);
			// ----------------------------------------
			// 👩‍🏫 Profesores
			modelBuilder.Entity<Profesor>().HasData(
				new Profesor { ProfesorId = 1, Nombre = "Ana Torres" },
				new Profesor { ProfesorId = 2, Nombre = "Carlos Gómez" },
				new Profesor { ProfesorId = 3, Nombre = "Laura Sánchez" },
				new Profesor { ProfesorId = 4, Nombre = "Miguel Ángel" },
				new Profesor { ProfesorId = 5, Nombre = "Patricia Ramírez" }
			);

			// ----------------------------------------
			// 📚 Materias (2 por profesor)
			modelBuilder.Entity<Materia>().HasData(
				new Materia { MateriaId = 1, Nombre = "Matemáticas", Creditos = 3, ProfesorId = 1 },
				new Materia { MateriaId = 2, Nombre = "Estadística", Creditos = 3, ProfesorId = 1 },
				new Materia { MateriaId = 3, Nombre = "Física", Creditos = 3, ProfesorId = 2 },
				new Materia { MateriaId = 4, Nombre = "Química", Creditos = 3, ProfesorId = 2 },
				new Materia { MateriaId = 5, Nombre = "Historia", Creditos = 3, ProfesorId = 3 },
				new Materia { MateriaId = 6, Nombre = "Literatura", Creditos = 3, ProfesorId = 3 },
				new Materia { MateriaId = 7, Nombre = "Programación", Creditos = 3, ProfesorId = 4 },
				new Materia { MateriaId = 8, Nombre = "Bases de Datos", Creditos = 3, ProfesorId = 4 },
				new Materia { MateriaId = 9, Nombre = "Inglés", Creditos = 3, ProfesorId = 5 },
				new Materia { MateriaId = 10, Nombre = "Francés", Creditos = 3, ProfesorId = 5 }
			);

			// ----------------------------------------
			// 👨‍🎓 Estudiantes (opcional - para pruebas)
			modelBuilder.Entity<Estudiante>().HasData(
				new Estudiante { EstudianteId = 1, Nombre = "Juan Pérez" },
				new Estudiante { EstudianteId = 2, Nombre = "María López" }
			);

			// ----------------------------------------
			// 📚 Relaciones EstudianteMateria (opcional - para pruebas)
			modelBuilder.Entity<EstudianteMateria>().HasData(
				// Juan Pérez (Estudiante 1)
				new EstudianteMateria { EstudianteId = 1, MateriaId = 1 },
				new EstudianteMateria { EstudianteId = 1, MateriaId = 3 },
				new EstudianteMateria { EstudianteId = 1, MateriaId = 5 },

				// María López (Estudiante 2)
				new EstudianteMateria { EstudianteId = 2, MateriaId = 2 },
				new EstudianteMateria { EstudianteId = 2, MateriaId = 4 },
				new EstudianteMateria { EstudianteId = 2, MateriaId = 7 }
			);
		}
	}
}
