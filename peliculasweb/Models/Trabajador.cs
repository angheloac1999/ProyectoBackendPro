using System.Collections.Generic;

namespace peliculasweb.Models
{
    public class Trabajador : Persona
    {
        public string Biografia { get; set; }
        public string Rol { get; set; }
        public ICollection<PeliculaTrabajador> PeliculaTrabajadores { get; set; }
    }
}