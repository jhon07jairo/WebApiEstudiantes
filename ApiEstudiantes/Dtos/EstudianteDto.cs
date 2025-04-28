namespace ApiEstudiantes.Dtos
{
	public class EstudianteDto
	{
		public int EstudianteId { get; set; }
		public string? Nombre { get; set; }

		// Materias asociadas al estudiante
		public List<MateriaDto> Materias { get; set; } = new();
	}

	public class MateriaDto
	{
		public int MateriaId { get; set; }
		public string? Nombre { get; set; }
		public string? ProfesorNombre { get; set; }
	}
}
