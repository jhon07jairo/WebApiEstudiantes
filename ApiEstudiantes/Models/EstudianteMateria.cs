namespace ApiEstudiantes.Models
{
	public class EstudianteMateria
	{
		public int EstudianteId { get; set; }
		public int MateriaId { get; set; }

		public Estudiante Estudiante { get; set; }
		public Materia Materia { get; set; }
	}

}
