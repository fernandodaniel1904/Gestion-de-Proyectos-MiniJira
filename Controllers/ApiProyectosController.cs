using Gestion_de_Proyectos_MiniJira.Data;
using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Proyectos_MiniJira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProyectosController : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ILogger<ApiProyectosController> _logger;

        public ApiProyectosController(IProyectoRepository proyectoRepository, ILogger<ApiProyectosController> logger)
        {
            _proyectoRepository = proyectoRepository;
            _logger = logger;
        }

        // GET: api/aproyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            var proyectos = await _proyectoRepository.GetAllAsync();
            return Ok(proyectos);
        }

        // GET: api/aproyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _proyectoRepository.GetByIdWithTareasAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(proyecto);
        }

        // POST: api/aproyectos
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _proyectoRepository.AddAsync(proyecto);
            await _proyectoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
        }

        // PUT: api/aproyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return BadRequest();
            }

            await _proyectoRepository.UpdateAsync(proyecto);
            await _proyectoRepository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/aproyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            await _proyectoRepository.DeleteAsync(id);
            await _proyectoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
