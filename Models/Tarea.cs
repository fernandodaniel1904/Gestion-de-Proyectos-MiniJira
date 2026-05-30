namespace Gestion_de_Proyectos_MiniJira.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaVencimiento { get; set; }
        public EstadoTarea Estado { get; set; } = EstadoTarea.PorHacer;
        public Prioridad Prioridad { get; set; } = Prioridad.Media;
        
        // Clave foránea
        public int ProyectoId { get; set; }
        
        // Relación inversa
        public Proyecto? Proyecto { get; set; }
    }

    public enum EstadoTarea
    {
        PorHacer = 1,
        EnProgreso = 2,
        Completada = 3
    }

    public enum Prioridad
    {
        Baja = 1,
        Media = 2,
        Alta = 3
    }
}
