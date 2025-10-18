using System.Collections.Generic;

namespace peliculasweb.Models
{
    public class Actor : Persona
    {
        public string Biografia { get; set; }
        public ICollection<PeliculaActor> PeliculaActores { get; set; }
    }
}