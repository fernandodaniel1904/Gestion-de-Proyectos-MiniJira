using Gestion_de_Proyectos_MiniJira.Data;
using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Proyectos_MiniJira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTareasController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly ILogger<ApiTareasController> _logger;

        public ApiTareasController(ITareaRepository tareaRepository, ILogger<ApiTareasController> logger)
        {
            _tareaRepository = tareaRepository;
            _logger = logger;
        }

        // GET: api/atareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            var tareas = await _tareaRepository.GetAllAsync();
            return Ok(tareas);
        }

        // GET: api/atareas/proyecto/5
        [HttpGet("proyecto/{proyectoId}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasByProyecto(int proyectoId)
        {
            var tareas = await _tareaRepository.GetTareasByProyectoAsync(proyectoId);
            return Ok(tareas);
        }

        // GET: api/atareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        // POST: api/atareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tareaRepository.AddAsync(tarea);
            await _tareaRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
        }

        // PUT: api/atareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            await _tareaRepository.UpdateAsync(tarea);
            await _tareaRepository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/atareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            await _tareaRepository.DeleteAsync(id);
            await _tareaRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
