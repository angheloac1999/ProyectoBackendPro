using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public ICollection<PeliculaActor> PeliculaActores { get; set; } = new List<PeliculaActor>();
    }
}
