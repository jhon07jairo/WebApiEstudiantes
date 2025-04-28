namespace ApiEstudiantes.Models
{
	public class Materia
	{
		public int MateriaId { get; set; }
		public string? Nombre { get; set; }
		public int Creditos { get; set; } = 3; // Siempre serán 3
		public int ProfesorId { get; set; }

		public Profesor Profesor { get; set; }
		public ICollection<EstudianteMateria> EstudianteMaterias { get; set; }
	}
}
