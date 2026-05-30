using Gestion_de_Proyectos_MiniJira.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Proyectos_MiniJira.Data
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Proyecto?> GetByIdWithTareasAsync(int id)
        {
            return await _context.Proyectos
                .Include(p => p.Tareas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Proyecto>> GetProyectosByEstadoAsync(EstadoProyecto estado)
        {
            return await _context.Proyectos
                .Where(p => p.Estado == estado)
                .Include(p => p.Tareas)
                .ToListAsync();
        }
    }
}
