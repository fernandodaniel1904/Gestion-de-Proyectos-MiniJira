using Gestion_de_Proyectos_MiniJira.Models;

namespace Gestion_de_Proyectos_MiniJira.Data
{
    public interface IProyectoRepository : IRepository<Proyecto>
    {
        Task<Proyecto?> GetByIdWithTareasAsync(int id);
        Task<IEnumerable<Proyecto>> GetProyectosByEstadoAsync(EstadoProyecto estado);
    }
}
