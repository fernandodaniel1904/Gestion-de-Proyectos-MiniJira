using System.ComponentModel.DataAnnotations;

namespace Gestion_de_Proyectos_MiniJira.Models
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        public ICollection<Tarea>? Tareas { get; set; }
    }
}
