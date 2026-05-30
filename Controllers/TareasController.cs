using Gestion_de_Proyectos_MiniJira.Data;
using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Proyectos_MiniJira.Controllers
{
    public class TareasController : Controller
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ILogger<TareasController> _logger;

        public TareasController(ITareaRepository tareaRepository, IProyectoRepository proyectoRepository, ILogger<TareasController> logger)
        {
            _tareaRepository = tareaRepository;
            _proyectoRepository = proyectoRepository;
            _logger = logger;
        }

        // GET: Tareas
        public async Task<IActionResult> Index(int? proyectoId)
        {
            IEnumerable<Tarea> tareas;

            if (proyectoId.HasValue)
            {
                tareas = await _tareaRepository.GetTareasByProyectoAsync(proyectoId.Value);
            }
            else
            {
                tareas = await _tareaRepository.GetAllAsync();
            }

            ViewBag.ProyectoId = proyectoId;
            return View(tareas);
        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _tareaRepository.GetByIdAsync(id.Value);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // GET: Tareas/Create
        public async Task<IActionResult> Create(int? proyectoId)
        {
            if (proyectoId.HasValue)
            {
                var proyecto = await _proyectoRepository.GetByIdAsync(proyectoId.Value);
                if (proyecto == null)
                {
                    return NotFound();
                }
                ViewBag.Proyecto = proyecto;
            }
            return View();
        }

        // POST: Tareas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descripcion,FechaVencimiento,Estado,Prioridad,ProyectoId")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                await _tareaRepository.AddAsync(tarea);
                await _tareaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { proyectoId = tarea.ProyectoId });
            }
            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _tareaRepository.GetByIdAsync(id.Value);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,FechaCreacion,FechaVencimiento,Estado,Prioridad,ProyectoId")] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tareaRepository.UpdateAsync(tarea);
                await _tareaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { proyectoId = tarea.ProyectoId });
            }
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _tareaRepository.GetByIdAsync(id.Value);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);
            if (tarea != null)
            {
                await _tareaRepository.DeleteAsync(id);
                await _tareaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { proyectoId = tarea.ProyectoId });
            }
            return NotFound();
        }
    }
}
