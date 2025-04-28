namespace ApiEstudiantes.Models
{
	public class Estudiante
	{
		public int EstudianteId { get; set; }
		public string? Nombre { get; set; }

		public ICollection<EstudianteMateria> EstudianteMaterias { get; set; }
	}
}
