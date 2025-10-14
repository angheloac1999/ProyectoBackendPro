using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class PeliculaActor
    {
        public int Id { get; set; }

        [Display(Name = "Pelicula")]
        public int IdPelicula { get; set; }

        [Display(Name = "Actor")]
        public int IdActor { get; set; }

        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
