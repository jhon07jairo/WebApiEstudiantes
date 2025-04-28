using ApiEstudiantes.Data;
using ApiEstudiantes.Dtos;  // Importamos la carpeta Dtos
using ApiEstudiantes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiantes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstudiantesController(ApiDbContext context) : ControllerBase
	{
		private readonly ApiDbContext _context = context;


		// ✅ GET: api/Estudiantes (listar todos los estudiantes)
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
		{
			return await _context.Estudiantes
				.Include(e => e.EstudianteMaterias)
					.ThenInclude(em => em.Materia)
				.ToListAsync();
		}

		// ✅ GET: api/Estudiantes/5 (detalle de un estudiante con materias)
		[HttpGet("{id}")]
		public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
		{
			var estudiante = await _context.Estudiantes
				.Include(e => e.EstudianteMaterias)
					.ThenInclude(em => em.Materia)
				.FirstOrDefaultAsync(e => e.EstudianteId == id);

			if (estudiante == null)
			{
				return NotFound();
			}

			return estudiante;
		}

		// ✅ POST: api/Estudiantes (crear un nuevo estudiante con materias)
		[HttpPost]
		public async Task<ActionResult<Estudiante>> PostEstudiante(EstudianteCreateDto estudianteDto)
		{
			// Validar que haya exactamente 3 materias seleccionadas
			if (estudianteDto.MateriasSeleccionadas.Count != 3)
			{
				return BadRequest("Debes seleccionar exactamente 3 materias.");
			}

			// Validar que los profesores de las materias sean diferentes
			var materiasIds = estudianteDto.MateriasSeleccionadas.Select(m => m.MateriaId).ToList();
			var materias = await _context.Materias
				.Where(m => materiasIds.Contains(m.MateriaId))
				.Include(m => m.Profesor)
				.ToListAsync();

			//var profesores = materias.Select(m => m.ProfesorId).Distinct().ToList();
			//if (profesores.Count != 3)
			//{
			//	return BadRequest("No puedes tener materias con el mismo profesor.");
			//}

			// Crear el estudiante
			var estudiante = new Estudiante
			{
				Nombre = estudianteDto.Nombre,
				EstudianteMaterias = estudianteDto.MateriasSeleccionadas.Select(m => new EstudianteMateria
				{
					MateriaId = m.MateriaId
				}).ToList()
			};

			_context.Estudiantes.Add(estudiante);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.EstudianteId }, estudiante);
		}

		// ✅ PUT: api/Estudiantes/5 (actualizar un estudiante y sus materias)
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEstudiante(int id, EstudianteCreateDto estudianteDto)
		{
			var estudiante = await _context.Estudiantes
				.Include(e => e.EstudianteMaterias)
				.FirstOrDefaultAsync(e => e.EstudianteId == id);

			if (estudiante == null)
			{
				return NotFound();
			}

			// Validar materias seleccionadas
			if (estudianteDto.MateriasSeleccionadas.Count != 3)
			{
				return BadRequest("Debes seleccionar exactamente 3 materias.");
			}

			var materiasIds = estudianteDto.MateriasSeleccionadas.Select(m => m.MateriaId).ToList();
			var materias = await _context.Materias
				.Where(m => materiasIds.Contains(m.MateriaId))
				.Include(m => m.Profesor)
				.ToListAsync();

			var profesores = materias.Select(m => m.ProfesorId).Distinct().ToList();
			if (profesores.Count != 3)
			{
				return BadRequest("No puedes tener materias con el mismo profesor.");
			}

			// Actualizar nombre
			estudiante.Nombre = estudianteDto.Nombre;

			// Actualizar las materias del estudiante
			estudiante.EstudianteMaterias.Clear();
			foreach (var materiaDto in estudianteDto.MateriasSeleccionadas)
			{
				estudiante.EstudianteMaterias.Add(new EstudianteMateria
				{
					EstudianteId = id,
					MateriaId = materiaDto.MateriaId
				});
			}

			await _context.SaveChangesAsync();

			return NoContent();
		}

		// ✅ DELETE: api/Estudiantes/5 (eliminar estudiante)
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEstudiante(int id)
		{
			var estudiante = await _context.Estudiantes
				.Include(e => e.EstudianteMaterias)
				.FirstOrDefaultAsync(e => e.EstudianteId == id);

			if (estudiante == null)
			{
				return NotFound();
			}

			_context.EstudianteMaterias.RemoveRange(estudiante.EstudianteMaterias);
			_context.Estudiantes.Remove(estudiante);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// ✅ GET: api/Estudiantes/5/companeros (ver estudiantes que comparten clases)
		[HttpGet("{id}/companeros")]
		public async Task<ActionResult<IEnumerable<object>>> GetCompanerosDeClase(int id)
		{
			var materiasDelEstudiante = await _context.EstudianteMaterias
				.Where(em => em.EstudianteId == id)
				.Select(em => em.MateriaId)
				.ToListAsync();

			if (!materiasDelEstudiante.Any())
			{
				return NotFound("El estudiante no tiene materias asignadas.");
			}

			var companeros = await _context.EstudianteMaterias
				.Where(em => materiasDelEstudiante.Contains(em.MateriaId) && em.EstudianteId != id)
				.Include(em => em.Estudiante)
				.GroupBy(em => em.MateriaId)
				.Select(g => new
				{
					MateriaId = g.Key,
					Companeros = g.Select(em => em.Estudiante.Nombre).Distinct().ToList()
				})
				.ToListAsync();

			return companeros;
		}
	}
}
