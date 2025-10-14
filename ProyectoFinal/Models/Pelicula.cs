using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public TimeSpan Duracion { get; set; }

        [Display(Name = "Fecha de estreno")]
        [DataType(DataType.Date)]
        public DateTime FechaEstreno { get; set; }

        [Display(Name = "Imagen")]
        public string RutaImagen { get; set; }

        [Display(Name = "Genero")]
        public int IdGenero { get; set; }

        [Display(Name = "Director")]
        public int IdDirector { get; set; }

        public Genero Genero { get; set; }
        public Director Director { get; set; }
        public ICollection<PeliculaActor> PeliculaActores { get; set; } = new List<PeliculaActor>();
    }
}
