namespace ApiEstudiantes.Dtos
{
	public class EstudianteCreateDto
	{
		public string? Nombre { get; set; }

		// Selección de materias
		public List<MateriaSeleccionadaDto> MateriasSeleccionadas { get; set; } = new();
	}

	public class MateriaSeleccionadaDto
	{
		public int MateriaId { get; set; }
	}
}
