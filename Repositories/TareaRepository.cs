using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Proyectos_MiniJira.Data
{
    public class TareaRepository : Repository<Tarea>, ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetTareasByProyectoAsync(int proyectoId)
        {
            return await _context.Tareas
                .Where(t => t.ProyectoId == proyectoId)
                .OrderByDescending(t => t.FechaCreacion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarea>> GetTareasByEstadoAsync(EstadoTarea estado)
        {
            return await _context.Tareas
                .Where(t => t.Estado == estado)
                .ToListAsync();
        }
    }
}
