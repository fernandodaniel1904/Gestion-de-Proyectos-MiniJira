namespace Gestion_de_Proyectos_MiniJira.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaVencimiento { get; set; }
        public EstadoProyecto Estado { get; set; } = EstadoProyecto.Activo;
        
        // Relaciones
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }

    public enum EstadoProyecto
    {
        Activo = 1,
        Pausado = 2,
        Finalizado = 3
    }
}
