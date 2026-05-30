using Gestion_de_Proyectos_MiniJira.Models;

namespace Gestion_de_Proyectos_MiniJira.Data
{
    public interface ITareaRepository : IRepository<Tarea>
    {
        Task<IEnumerable<Tarea>> GetTareasByProyectoAsync(int proyectoId);
        Task<IEnumerable<Tarea>> GetTareasByEstadoAsync(EstadoTarea estado);
    }
}
