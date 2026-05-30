using System.ComponentModel.DataAnnotations;

namespace Gestion_de_Proyectos_MiniJira.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        public EstadoTarea Estado { get; set; } = EstadoTarea.PorHacer;
        public Prioridad Prioridad { get; set; } = Prioridad.Media;

        public int ProyectoId { get; set; }
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
