using System;

namespace peliculasweb.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }

        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}