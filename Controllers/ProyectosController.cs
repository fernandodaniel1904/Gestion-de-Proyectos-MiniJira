using Gestion_de_Proyectos_MiniJira.Data;
using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Proyectos_MiniJira.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ILogger<ProyectosController> _logger;

        public ProyectosController(IProyectoRepository proyectoRepository, ILogger<ProyectosController> logger)
        {
            _proyectoRepository = proyectoRepository;
            _logger = logger;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
            var proyectos = await _proyectoRepository.GetAllAsync();
            return View(proyectos);
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _proyectoRepository.GetByIdWithTareasAsync(id.Value);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Descripcion,FechaVencimiento,Estado")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                await _proyectoRepository.AddAsync(proyecto);
                await _proyectoRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _proyectoRepository.GetByIdAsync(id.Value);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaCreacion,FechaVencimiento,Estado")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _proyectoRepository.UpdateAsync(proyecto);
                await _proyectoRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _proyectoRepository.GetByIdAsync(id.Value);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _proyectoRepository.DeleteAsync(id);
            await _proyectoRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
