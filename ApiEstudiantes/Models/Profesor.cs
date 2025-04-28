﻿namespace ApiEstudiantes.Models
{
	public class Profesor
	{
		public int ProfesorId { get; set; }
		public string? Nombre { get; set; }

		public ICollection<Materia> Materias { get; set; }
	}

}
