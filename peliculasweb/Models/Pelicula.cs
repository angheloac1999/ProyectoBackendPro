using System;
using System.Collections.Generic;

namespace peliculasweb.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public int Duracion { get; set; } // en minutos
        public DateTime FechaEstreno { get; set; }
        public string Imagen { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public ICollection<PeliculaTrabajador> PeliculaTrabajadores { get; set; }
        public ICollection<PeliculaActor> PeliculaActores { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Proyeccion> Proyecciones { get; set; }
    }
}