namespace ApiEstudiantes.Dtos
{
	public class CompanerosDto
	{
		public int MateriaId { get; set; }
		public List<string> Companeros { get; set; } = new();
	}
}
