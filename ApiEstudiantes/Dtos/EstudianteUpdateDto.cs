namespace ApiEstudiantes.Dtos
{
	public class EstudianteUpdateDto
	{
		public string? Nombre { get; set; }

		// Selección de materias para actualizar
		public List<MateriaSeleccionadaDto> MateriasSeleccionadas { get; set; } = new();
	}
}
